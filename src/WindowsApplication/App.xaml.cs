using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Automation;
using WindowsApplication.AutomationHandlers;
using System.Threading;
using WindowsApplication.Services;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static MyServiceProvider ServiceProvider { get; } = new();
        private NotifyIcon? trayIcon;

        void Application_Startup(object sender, StartupEventArgs e)
        {
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

        private ContextMenuStrip createMenu()
        {
            ContextMenuStrip Menu = new ContextMenuStrip();
            ToolStripItem exitItem = new ToolStripMenuItem("Exit Justa");
            exitItem.Click += new EventHandler(CloseApplication);
            Menu.Items.Add(exitItem);
            return Menu;
        }

        private void CloseApplication(object? sender, EventArgs e)
        {
            this.Shutdown();
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
