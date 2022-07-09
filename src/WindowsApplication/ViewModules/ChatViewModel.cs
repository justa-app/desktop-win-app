using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowsApplication.Interfaces;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class ChatViewModel : ObservableObject
    {
        public ObservableCollection<ChatItemViewModel> Messages { get; } = new();
        public string ChatID { get; }
        public string Subject { get; }
        public string newMessageText { get; set; } = "";

        public ICommand SendMessage { get; }

        public ChatViewModel(string chatID, string subject)
        {
            ChatID = chatID;
            Subject = subject;

            // , () => newMessageText != ""
            SendMessage = new RelayCommand(sendMessageFromBox, () => newMessageText != "");
            //SendMessage = new RelayCommand(sendMessageFromBox);



            Task<object> getMessages = App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.ListMessagesMessageSessionIdGetAsync(ChatID);
            getMessages.ContinueWith((f) => onNewMessages(f.Result));
            // App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
        }

        private void onNewMessages(object messagesTask)
        {
            JObject a = (JObject)messagesTask;
            
            JArray arr = (JArray)a.GetValue("messages");
            JToken b;
            arr.ToList().ForEach(x => {
                JObject obj = x.ToObject<JObject>();
                Messages.Add(new ChatItemViewModel(false, (string)obj.GetValue("content")));
                }
            );

        }

        private async void sendMessageFromBox()
        {
            // TODO This message object should be the datacontext to every message in the list
            App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.CreateMessageMessagePost(new Client.Model.Message(ChatID, "me", newMessageText));
            newMessageText = "";
            OnPropertyChanged("newMessageText");

            object getMessages = await App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
                ListMessagesMessageSessionIdGetAsync(ChatID, skip:Messages.Count-1);
            
            onNewMessages(getMessages);
            
        }

    }
}
