using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Diagnostics;

namespace WindowsApplication.AutomationHandlers
{
    public class OutlookFocusHandler
    {
        readonly static string OUTLOOK_PROCESS_NAME = "OUTLOOK";
        readonly static string OUTLOOK_MESSAGE_AUTOMATION_NAME = "Message";
        readonly static string OUTLOOK_MESSAGE_AUTOMATION_ID = "Untitled Message";

        public AutomationElement sourceElement { get; private set; }
        public string Text { get; private set; }

        public static bool IsFocused(AutomationElement sourceElement)
        {
            // Checks if the parent is message of outlook:
            // if the name of the process is `outlook` and the second parent of the content is the 
            // message window (detected by AutomationId
            if (
                Process.GetProcessById(sourceElement.Current.ProcessId).ProcessName != OUTLOOK_PROCESS_NAME
                    ) return false;

            TreeWalker tree = TreeWalker.ControlViewWalker;
            AutomationElement el = tree.GetParent(sourceElement);
            if (el == null) return false;
            el = tree.GetParent(el);
            return (
                sourceElement != null &&
                sourceElement.Current.Name == OUTLOOK_MESSAGE_AUTOMATION_ID) || (
                el != null &&
                el.Current.Name == OUTLOOK_MESSAGE_AUTOMATION_ID);
        }

        Action<string> textAction;
        public OutlookFocusHandler(AutomationElement sourceElement, Action<string> textAction)
        {
            this.textAction = textAction;
            this.sourceElement = sourceElement;
        }

        public void OnFocus()
        {
            Automation.AddAutomationEventHandler(TextPattern.TextChangedEvent, sourceElement, TreeScope.Element, onTextChange);
        }

        private void onTextChange(object sender, AutomationEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            AutomationElement automationElement = sender as AutomationElement;
            object pattern;
            TextPattern textPattern;

            if (automationElement.TryGetCurrentPattern(TextPattern.Pattern, out pattern))
            {
                textPattern = pattern as TextPattern;
                Text = textPattern.DocumentRange.GetText(1000);
                textAction(Text);
            }
        }

        public void OnLostFocus()
        {
            Automation.RemoveAutomationEventHandler(
                TextPattern.TextChangedEvent,
                sourceElement,
                onTextChange
                );
        }
    }
}
