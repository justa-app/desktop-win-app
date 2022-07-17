using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Automation;
using WindowsApplication.AutomationHandlers;
using System.Threading;
using WindowsApplication.Services;
using WindowsApplication.Utilities;
using WindowsApplication.Interfaces;
using WindowsApplication.Dialogs.YesNo;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : SingleRunApplication
    {
        
        public static MyServiceProvider ServiceProvider { get; } = new();
        private NotifyIcon? trayIcon;


        void Application_Startup(object sender, StartupEventArgs e)
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            trayIcon = new NotifyIcon()
            {
                Icon=new Icon("Assets/JustaSleep.ico"),
                Text="Justa",
                ContextMenuStrip = this.createMenu(),
                Visible = true
            };

            // TODO the correct thing to do is having 2 windows that follow each other

            MainWindow window = new MainWindow();
            window.Visibility = Visibility.Hidden;
            window.Show();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            System.Windows.MessageBox.Show(e.Exception.ToString(), "A critical exception occured");
        }

        private ContextMenuStrip createMenu()
        {
            ContextMenuStrip Menu = new ContextMenuStrip();
            
            ToolStripItem settingsItem= new ToolStripMenuItem("Settings");
            Menu.Items.Add(settingsItem);

            ToolStripItem feedbackItem = new ToolStripMenuItem("Send Feedback");
            feedbackItem.Click += new EventHandler(OpenMail);
            Menu.Items.Add(feedbackItem);

            ToolStripItem exitItem = new ToolStripMenuItem("Exit Justa");
            exitItem.Click += new EventHandler(CloseApplication);
            Menu.Items.Add(exitItem);
            return Menu;
        }

        private void CloseApplication(object? sender, EventArgs e)
        {
            this.Shutdown();
        }

        private void OpenMail(object? sender, EventArgs e)
        {   
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("mailto:ask@justa.app");
            info.UseShellExecute = true;
            System.Diagnostics.Process.Start(info);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // close all open windows and the tray Icon

            foreach (Window i in this.Windows)
            {
                i.Close();
            }
            if (this.trayIcon != null)
            {
                this.trayIcon.Dispose();
            }
        }
    }
}
