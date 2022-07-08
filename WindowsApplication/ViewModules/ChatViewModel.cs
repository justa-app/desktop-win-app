using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class ChatViewModel : ObservableObject
    {
        public ObservableCollection<ChatItemViewModel> Messages { get; set; }

        private string _subject;
        public string Subject { get => _subject; private set
            {
                _subject = value;
                OnPropertyChanged("Subject");
            } }

        public ChatViewModel(string subject)
        {
            Subject = subject;
            Messages = new ObservableCollection<ChatItemViewModel>();
            Messages.Add(new ChatItemViewModel(false, "hi what is it?"));
            Messages.Add(new ChatItemViewModel(true, "Nothing"));
        }

    }
}
