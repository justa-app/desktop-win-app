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
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            EventHandler handler = async (sender, e) => {
                try
                {
                    object getMessages = await App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
                    ListSessionMessagesMessageGetAsync(ChatID, skip: Messages.Count);

                    onNewMessages(getMessages);
                } catch(Exception ee)
                {
                    // this code will be deleted shortly
                }
            };
            dispatcherTimer.Tick += handler;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
            //SendMessage = new RelayCommand(sendMessageFromBox);



            /*Task<object> getMessages = App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.ListSessionMessagesMessageGetAsync(ChatID);
            getMessages.ContinueWith((f) => onNewMessages(f.Result));*/
            // App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
        }

        private void onNewMessages(object messagesTask)
        {
            JArray arr = (JArray)messagesTask;
            JToken b;
            arr.ToList().ForEach(x => {
                JObject obj = x.ToObject<JObject>();
                Messages.Add(new ChatItemViewModel((string)obj.GetValue("expert_id") == "", (string)obj.GetValue("content")));
                }
            );

        }

        private void sendMessageFromBox()
        {
            // TODO This message object should be the datacontext to every message in the list
            App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.CreateMessageMessagePost(new Client.Model.Message(ChatID, "", newMessageText));
            newMessageText = "";
            OnPropertyChanged("newMessageText");
            /*
            object getMessages = await App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
                ListSessionMessagesMessageGetAsync(ChatID, skip:Messages.Count);
            
            onNewMessages(getMessages);*/
            
        }

    }
}
