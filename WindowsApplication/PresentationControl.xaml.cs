using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using WindowsApplication.Command;
using WindowsApplication.ViewModules;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for PresentationControl.xaml
    /// </summary>
    public partial class PresentationControl : UserControl
    {
        // TODO move to a view model
        private int _index;
        public int Index {
            get => _index;
            set
            {
                _index = value;
                this.ViewedItem.Content = Slides[_index];
            }
        }

        public object[] Slides
        {
            get { return (object[])GetValue(SlidesProperty); }
            set { 
                SetValue(SlidesProperty, value);
                this.Index = 0;
            }
        }

        public int NumberOfSlides
        {
            get => Slides.Length;
        }

        public static readonly DependencyProperty SlidesProperty =
            DependencyProperty.Register("Slides", typeof(object[]), typeof(PresentationControl));


        public RelayCommand IncreaseIndex { get; private set; }
        public RelayCommand DecreaseIndex { get; private set; }
        public RelayCommand SetIndex { get; private set; }

        public PresentationControl()
        {
            InitializeComponent();
            DataContext = this;
            this.IncreaseIndex = new RelayCommand(
                r => this.Index + 1 < this.Slides.Length,
                r => this.Index++
                );

            this.DecreaseIndex = new RelayCommand(
                r => this.Index - 1 > -1,
                r => this.Index--
                );

            this.SetIndex = new RelayCommand(r =>
            {
                int ind = (int)r;
                return ind < this.Slides.Length && ind >= 0;
            }, r =>
            {
                this.Index = (int)r;
            });

        }
    }
}
