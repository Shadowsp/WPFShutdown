using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WPFShutdown
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
    //    Configuration configWindow = new Configuration();
      //  NotifyIcon notifyIcon = new NotifyIcon();
        //  Configuration configWindow = new Configuration();
        MainWindow Main = new MainWindow();

        public TaskTrayApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = WPFShutdown.Properties.Resources.Cool ;
            notifyIcon.DoubleClick += new EventHandler(ShowConfig);
            notifyIcon.ContextMenu = new  ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
        }

        void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
         //   if (WPFShutdown.Properties.Settings.Default.ShowMessage)
            //    MessageBox.Show("Hello World");
        }

        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            //if (configWindow.Visible)
            //    configWindow.Focus();
            //else
            //    configWindow.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
