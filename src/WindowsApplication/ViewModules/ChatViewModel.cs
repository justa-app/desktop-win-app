using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using WindowsApplication.Client.Model;
using WindowsApplication.Interfaces;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class ChatViewModel : ObservableObject
    {
        public ObservableCollection<ResievedMessage> Messages { get; } = new();
        public string ChatID { get; }
        public string Subject { get; }
        private string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; OnPropertyChanged("MessageText"); }
        }


        public ICommand SendMessage { get; }

        public ChatViewModel(string chatID, string subject)
        {
            ChatID = chatID;
            Subject = subject;
            MessageText = "";

            SendMessage = new RelayCommand(sendMessageFromBox, () => MessageText != "");
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            EventHandler handler = async (sender, e) => {
                try
                {
                    object getMessages = await App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.
                    ListSessionMessagesMessageGetAsync(ChatID, skip: Messages.Count);

                    onNewMessages(getMessages);
                } catch(Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                    // this code will be deleted shortly
                }
            };
            dispatcherTimer.Tick += handler;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }

        private void onNewMessages(object messagesTask)
        {
            JArray arr = (JArray)messagesTask;
            JToken b;
            arr.ToList().ForEach(x => {
                JObject obj = x.ToObject<JObject>();
                Messages.Add(obj.ToObject<ResievedMessage>());
                }
            );

        }

        private void sendMessageFromBox()
        {
            App.ServiceProvider.GetService<IJustaSessionService>().JustaApi.CreateMessageMessagePost(new Client.Model.Message(ChatID, "", MessageText));
            MessageText = "";
        }

    }




    /// <summary>
    /// Message
    /// </summary>
    [DataContract(Name = "RecievedMessage")]
    public partial class ResievedMessage
    {
        [JsonConstructorAttribute]
        protected ResievedMessage() { }
        public ResievedMessage(string timestamp, string expertId, string content)
        {
            this.ExpertId = expertId;
            this.Timestamp = timestamp;
            this.Content = content;
        }

        [DataMember(Name = "ts_creation", IsRequired = true, EmitDefaultValue = false)]
        public string Timestamp { get; set; }
        [DataMember(Name = "expert_id", IsRequired = true, EmitDefaultValue = false)]
        public string ExpertId { get; set; }

        [DataMember(Name = "content", IsRequired = true, EmitDefaultValue = false)]
        public string Content { get; set; }
    }
}
