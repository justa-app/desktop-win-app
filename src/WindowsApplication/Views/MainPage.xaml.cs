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
using WindowsApplication.Pages;
using WindowsApplication.ViewModules;

namespace WindowsApplication.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainWindowViewModel _model;

        public MainPage(MainWindowViewModel datacontext)
        {
            _model = datacontext;
            this.DataContext = datacontext;
            InitializeComponent();

        }

        private void PresentationControl_IncreaseIndex(object sender, RoutedEventArgs e)
        {
            if (_model.client.LastUpdatedResponse.Length > _model.Index + 1)
            {
                _model.Index++;
            } else
            {
                _model.Index = 0;
            }

        }
        private void PresentationControl_DecreaseIndex(object sender, RoutedEventArgs e)
        {
            if (0 <= _model.Index - 1)
            {
                _model.Index--;
            } else
            {
                _model.Index = _model.client.LastUpdatedResponse.Length - 1;
            }
        }

        private void expert_StartChat(object sender, RoutedEventArgs e)
        {
            var page = new StartChatPage();
            page.Return += StartChatReturnSubject;
            this.NavigationService.Navigate(page);
        }

        private async void StartChatReturnSubject(object sender, ReturnEventArgs<string> e)
        {
            string subject = e.Result;
            List<string> experts = new List<string>();
            experts.Add("alice");
            experts.Add("bob");

            var newSession = new Client.Model.Session(name: subject, initiator: "john", experts: experts);

            JObject response = (JObject)await App.ServiceProvider.GetService<IJustaSessionService>().
                JustaApi.CreateSessionSessionPostAsync(newSession);

            JToken? id;
            if (!response.TryGetValue("session_id", StringComparison.OrdinalIgnoreCase, out id))
            {
                MessageBox.Show("There was a problem creating the session."); // TODO more data
                return;
            }


            var page = new ChatViewModel(id.ToObject<string>(), subject);
            this.NavigationService.Navigate(new ChatPage() { DataContext = page });
        }
    }
}
