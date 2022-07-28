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
    public partial class StartChatPage : PageFunction<String>
    {
        public ICommand StartChatCommand { get; set; }
        private string startingText;
        public StartChatPage(string startingText)
        {
            InitializeComponent();
            this.startingText = startingText is null? "":startingText;
            this.Loaded += StartChatPage_Loaded;
            // TODO create view model
            StartChatCommand = new RelayCommand(ChangeWindow, () => StartChatTextBox.Text != "");
            this.StartChatButton.Command = StartChatCommand;
        }

        private void StartChatPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (startingText.Contains('?'))
            {
                startingText = string.Join(
                    Environment.NewLine,
                    startingText.Split(
                        '?',
                        StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
                    ).Select(s => s.Split('.').Last().TrimStart() + "?")
                );
            }
            StartChatTextBox.Text = startingText;
        }

        private void ChangeWindow()
        {
            this.OnReturn(new ReturnEventArgs<string>(StartChatTextBox.Text));
        }
    }
}
