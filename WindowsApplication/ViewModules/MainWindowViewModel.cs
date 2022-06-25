using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using WindowsApplication.AutomationHandlers;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class MainWindowViewModel : ObservableObject
    {
        //public VisibilityViewModel vis { get; private set; }
        private bool _hasOutlookFocusHandler;
        public bool HasOutlookFocusHandler
        {
            get => _hasOutlookFocusHandler;
            set
            {
                this._hasOutlookFocusHandler = value;
                onPropertyChanged("HasOutlookFocusHandler");
            }
        }

        AutomationFocusChangedEventHandler? focusHandler;

        // the focus handler should be a class that is initialized and set to the last focused one
        // not a list of initialized ones
        private OutlookFocusHandler? _outlookFocusHandler;
        public OutlookFocusHandler? OutlookFocusHandler { get => _outlookFocusHandler; private set {
                _outlookFocusHandler = value;
                onPropertyChanged("OutlookFocusHandler");
                HasOutlookFocusHandler = value != null;
            }
        }

        public MainWindowViewModel()
        {
            OutlookFocusHandler = null;
        }

        public void registerFocusChangeHandler()
        {
            focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        public void unregisterFocusChangeHandler()
        {
            if (focusHandler != null)
            {
                Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
                OutlookFocusHandler?.OnLostFocus();
            }
        }

        private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {
            // NOTE this function is called in a seperate thread so there is no side effects
            // on the ui thread

            AutomationElement? sourceElement;
            try
            {
                sourceElement = src as AutomationElement;
                if (sourceElement == null)
                {
                    OutlookFocusHandler = null;
                    return;
                };

                if (sourceElement.Current.ProcessId == Process.GetCurrentProcess().Id) return;

                if (OutlookFocusHandler != null && OutlookFocusHandler.sourceElement == sourceElement) return;

                if (OutlookFocusHandler.IsFocused(sourceElement))
                {
                    OutlookFocusHandler focusHandler = new OutlookFocusHandler(sourceElement);
                    if (OutlookFocusHandler != null) OutlookFocusHandler.OnLostFocus();
                    OutlookFocusHandler = focusHandler;
                    if (focusHandler != null) focusHandler.OnFocus();
                } else
                {
                    if (OutlookFocusHandler != null) OutlookFocusHandler.OnLostFocus();
                    OutlookFocusHandler = null;
                }
            }
            catch (ElementNotAvailableException)
            {
                return;
            }

        }
    }
}
