using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Forms;

namespace WPFShutdown
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       NotifyIcon notifyIcon = new NotifyIcon();
      //  Configuration configWindow = new Configuration();
     //   MainWindow Main = new MainWindow();


        //Timer t1 = new Timer(); // Timer anlegen
        DateTime dtShutdowntime;
        public MainWindow()
        {
            InitializeComponent();
           // this.Visibility = false;
            this.Visibility = System.Windows.Visibility.Hidden ;

            System.Windows.Forms.MenuItem configMenuItem = new System.Windows.Forms.MenuItem("Hauptprogramm anzeigen", new EventHandler(showWPF));
            //InstandStandby
          System.Windows.Forms.MenuItem Sep = new System.Windows.Forms.MenuItem("-");
            
            System.Windows.Forms.MenuItem StandbyMenuItem = new System.Windows.Forms.MenuItem("Standby", new EventHandler(InstandStandby));
            // System.Windows.Forms.MenuItem SS = new System.Windows.Forms.MenuItem(
           System.Windows.Forms.MenuItem SepB = new System.Windows.Forms.MenuItem("-");
            System.Windows.Forms.MenuItem ShutdownMenuItem = new System.Windows.Forms.MenuItem("Shutdown", new EventHandler(InstandSHutdown));
            System.Windows.Forms.MenuItem SepA = new System.Windows.Forms.MenuItem("-");
            System.Windows.Forms.MenuItem exitMenuItem = new System.Windows.Forms.MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = WPFShutdown.Properties.Resources.Cool;
            notifyIcon.DoubleClick += new EventHandler(showWPF);
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(new System.Windows.Forms.MenuItem[] { configMenuItem, Sep, StandbyMenuItem,SepB, ShutdownMenuItem, SepA, exitMenuItem });
            notifyIcon.Visible = true;


        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showWPF(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Visible;
            this.Focus();
            if (!this.IsFocused)
            {
                this.Focus();
            }

        }

        private void txthour_TextInput(object sender, TextCompositionEventArgs e)
        {

            //switch (Strings.Asc(e.KeyChar))
            //{
            //    case 8:
            //    case 48:
            //    case 49:
            //    case 50:
            //    case 51:
            //    case 52:
            //    case 53:
            //    case 54:
            //    case 55:
            //    case 56:
            //    case 57:
            //        break;
            //    // Zahlen und Backspace zulassen
            //    default:
            //        // alle anderen Eingaben unterdrücken
            //        e.Handled = true;
            //        break;
            //}


        }

        //private void txthour_KeyDown(object sender, KeyEventArgs e)
        //{
        //    int a = 0;

        //    //Int32.TryParse(txthour.Text, out a);

        //    if (!String.IsNullOrEmpty(txthour.Text))
        //        int.TryParse(txthour.Text, out a);

        //    MessageBox.Show(a.ToString());

        //    //switch (Asc(e.Key))
        //    //{
        //    //    case 8:
        //    //    case 48:
        //    //    case 49:
        //    //    case 50:
        //    //    case 51:
        //    //    case 52:
        //    //    case 53:
        //    //    case 54:
        //    //    case 55:
        //    //    case 56:
        //    //    case 57:
        //    //        break;
        //    //    // Zahlen und Backspace zulassen
        //    //    default:
        //    //        // alle anderen Eingaben unterdrücken
        //    //        e.Handled = true;
        //    //        break;
        //    //}
        //    //Int32.TryParse
        //}

        private void txthour_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a = 0;

            //Int32.TryParse(txthour.Text, out a);

            if (!String.IsNullOrEmpty(txthour.Text))
                int.TryParse(txthour.Text, out a);

            if (a == 0)
                e.Handled = true;
          //  e.UndoAction = true;
           // MessageBox.Show(e.UndoAction.ToString());
            //if (txthour.CanUndo == true)

            //    txthour.Undo();
            //txthour.cl

            //txthour.Undo();


            //MessageBox.Show(a.ToString());
        }

        private void btnshutdown_Click(object sender, RoutedEventArgs e)
        {
            clsShutdown oShutdown = new clsShutdown();
            

           // TimeSpan ts;
            if (rbutUhrzeit.IsChecked == true )
            {
                oShutdown.Shutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
                // dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
            }
            else if (rbutDatum.IsChecked == true)
            {
                oShutdown.Shutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text)); 
                //dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text)); 
            }
           // oShutdown.dtShutdowntime = new DateTime( dtShutdowntime);


          //  dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,Convert.ToInt32( txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
            //dtShutdowntime.AddHours(1);

           // datePicker1.text;

            //MessageBox.Show(datePicker1.Text.ToString());
           // datePicker1.va
            //dtShutdowntime.AddHours(Convert.ToDouble(txthour.Text));
            //dtShutdowntime.AddMinutes (Convert.ToDouble(txtmin.Text));
            //dtShutdowntime.AddSeconds (Convert.ToDouble(txtsec.Text));
           // oShutdown.Ruhezustand = true;

            if (txthour.Text == String.Empty && txtmin.Text == String.Empty && txtsec.Text == String.Empty)
            {
                //oShutdown
                oShutdown.Shutdown();

                //Shutdown();


            }
            else
            {
                if (rbutDatum.IsChecked == true)
                {
                    oShutdown.Start_disTimer(true);
                }
                else
                {

                    oShutdown.Start_disTimer();
                    //                oShutdown
                    //ini_timer();

                }
            }

        }

        private void Shutdown()
        {
           // MessageBox.Show("SHUTDOWN!!!");
          System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 10");

        }
        private void Shutdown(DateTime dtZeit)
        {
            


        }

        private bool timecompare(DateTime shutdowntime)
        {
            //DateTime.Now;

            if (DateTime.Compare(DateTime.Now, shutdowntime) >= 0)
            {
                Shutdown();
            }




            return false;
        }
        private bool timecompare(DateTime shutdowntime, bool datetoo)
        {
            if (datetoo)
            {

                if (string.Compare(DateTime.Now.Hour.ToString(), shutdowntime.Hour.ToString()) == 0 && string.Compare(DateTime.Now.Minute.ToString(), shutdowntime.Minute.ToString()) == 0 && string.Compare(DateTime.Now.Year .ToString(), shutdowntime.Year .ToString()) == 0 && string.Compare(DateTime.Now.Month.ToString(), shutdowntime.Month.ToString()) == 0 && string.Compare(DateTime.Now.Day.ToString(), shutdowntime.Day.ToString()) == 0)
                {
                    Shutdown();

                }


            }

            else
            {


                if (string.Compare(DateTime.Now.Hour.ToString(), shutdowntime.Hour.ToString()) == 0 && string.Compare(DateTime.Now.Minute.ToString(), shutdowntime.Minute.ToString()) == 0)
                //if (DateTime.Compare(DateTime.Now.Hour , shutdowntime.Hour ) == 0)
                {
                    Shutdown();
                }
            }

            return true ;
        }


#region Time

//        Timer t1 = new Timer(); // Timer anlegen
//t1.Interval = 100; // Intervall festlegen, hier 100 ms
//t1.Tick+=new EventHandler(t1_Tick); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird
//t1.Start(); // Timer starten

void t1_Tick(object sender, EventArgs e)
{
// dieser Code wird ausgeführt, wenn der Timer abgelaufen ist
}


private void ini_timer()
{

    DispatcherTimer dispatcherTimer = new DispatcherTimer();

    dispatcherTimer.Tick += new EventHandler(timer_tick);

    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

    dispatcherTimer.Start();


}


#endregion

private void timer_tick(object sender, EventArgs e)
{



    if (timecompare(dtShutdowntime,false))
    {


    }
    

   // return true;
}

private void btnStandby_Click(object sender, RoutedEventArgs e)
{


    clsShutdown oShutdown = new clsShutdown();


    // TimeSpan ts;
    if (rbutUhrzeit.IsChecked == true)
    {
        oShutdown.Shutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
        // dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
    }
    else if (rbutDatum.IsChecked == true)
    {
        oShutdown.Shutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
        //dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text)); 
    }
    // oShutdown.dtShutdowntime = new DateTime( dtShutdowntime);


    //  dtShutdowntime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,Convert.ToInt32( txthour.Text), Convert.ToInt32(txtmin.Text), Convert.ToInt32(txtsec.Text));
    //dtShutdowntime.AddHours(1);

    // datePicker1.text;

    //MessageBox.Show(datePicker1.Text.ToString());
    // datePicker1.va
    //dtShutdowntime.AddHours(Convert.ToDouble(txthour.Text));
    //dtShutdowntime.AddMinutes (Convert.ToDouble(txtmin.Text));
    //dtShutdowntime.AddSeconds (Convert.ToDouble(txtsec.Text));
    oShutdown.Ruhezustand = true;

    if (txthour.Text == String.Empty && txtmin.Text == String.Empty && txtsec.Text == String.Empty)
    {
        //oShutdown
        oShutdown.Shutdown();

        //Shutdown();


    }
    else
    {
        if (rbutDatum.IsChecked == true)
        {
            oShutdown.Start_disTimer(true);
        }
        else
        {

            oShutdown.Start_disTimer();
            //                oShutdown
            //ini_timer();

        }
    }
    //InstandStandby(sender, e);

    //clsShutdown oShut = new clsShutdown();
    //oShut.Ruhezustand = true;
    //oShut.Shutdown();
}


private void InstandStandby(object sender, EventArgs e)
{
    clsShutdown oShut = new clsShutdown();
    oShut.Ruhezustand = true;
    oShut.Shutdown();
}

private void InstandSHutdown(object sender, EventArgs e)
{
    clsShutdown oShut = new clsShutdown();
    
    oShut.Time = true;

    oShut.Times = "1";
    oShut.Force = true;
    oShut.Shutdown();


}

private void Window_LostFocus(object sender, RoutedEventArgs e)
{
   // this.Visibility = System.Windows.Visibility.Hidden;
   // this.
}

private void Window_Deactivated(object sender, EventArgs e)
{
    this.Visibility = System.Windows.Visibility.Hidden;
}


    }
}
