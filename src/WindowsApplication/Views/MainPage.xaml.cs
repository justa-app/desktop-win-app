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
            }

        }
        private void PresentationControl_DecreaseIndex(object sender, RoutedEventArgs e)
        {
            if (0 <= _model.Index - 1)
            {
                _model.Index--;
            }
        }

        private void expert_StartChat(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(App.ServiceProvider.GetService<StartChatPage>());
        }
    }
}
