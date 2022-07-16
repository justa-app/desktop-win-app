using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsApplication.Interfaces;
using WindowsApplication.Utilities;
using WindowsApplication.ViewModules;
using WindowsApplication.Views;

namespace WindowsApplication.Pages
{
    /// <summary>
    /// Interaction logic for StartChatPage.xaml
    /// </summary>
    public partial class StartChatPage : Page
    {
        public ICommand StartChatCommand { get; set; }
        public StartChatPage()
        {
            InitializeComponent();

            // TODO create view model
            StartChatCommand = new RelayCommand(ChangeWindow, () => StartChatTextBox.Text != "");
            this.StartChatButton.Command = StartChatCommand;
        }

        private async void ChangeWindow()
        {
            // TODO probably send the async request while changing page
            List<string> experts = new List<string>();
            experts.Add("alice");
            experts.Add("bob");

            var newSession = new Client.Model.Session(name: StartChatTextBox.Text, initiator: "john", experts: experts);

            JObject response = (JObject)await App.ServiceProvider.GetService<IJustaSessionService>().
                JustaApi.CreateSessionSessionPostAsync(newSession);

            JToken? id;
            if (response.TryGetValue("session_id", StringComparison.OrdinalIgnoreCase, out id))
            {
                string chatId = id.ToObject<string>();
                this.NavigationService.Navigate(new ChatPage() { DataContext = new ChatViewModel(chatId, StartChatTextBox.Text) });
            }
            else
            {
                MessageBox.Show("There was a problem creating the session."); // TODO more data
            }


        }
    }
}
