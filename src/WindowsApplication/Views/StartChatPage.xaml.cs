using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WindowsApplication.Client.Model;
using WindowsApplication.Interfaces;
using WindowsApplication.ViewModules;

namespace WindowsApplication.Views
{

    /// <summary>
    /// Interaction logic for StartChatPage.xaml
    /// </summary>
    public partial class StartChatPage : Page
    {
        public StartChatPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // TODO probably send the async request while changing page
            List<string> experts = new List<string>();
            experts.Add("alice");
            experts.Add("bob");

            Session newSession = new Client.Model.Session(name: txtUserEntry.Text, initiator: "john", experts: experts);

            JObject response = (JObject)await App.ServiceProvider.GetService<IJustaSessionService>().
                JustaApi.CreateSessionSessionPostAsync(newSession);

            JToken? id;
            if (response.TryGetValue("session_id", StringComparison.OrdinalIgnoreCase, out id))
            {
                string chatId = id.ToObject<string>();
                this.NavigationService.Navigate(new ChatPage() { DataContext = new ChatViewModel(chatId, txtUserEntry.Text) });
            } else
            {
                MessageBox.Show("There was a problem creating the session."); // TODO more data
            }

            
        }
    }
}
