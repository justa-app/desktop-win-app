using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication.ViewModules
{
    public class ChatItemViewModel
    {
        public bool IsOrigin { get; set; }
        public string Text { get; set; }


        public ChatItemViewModel(bool isOrigin, string text)
        {
            Text = text;
            IsOrigin = isOrigin;
        }
    }
}
