using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace WPFShutdown
{
    class clsShutdown
    {
        
        private bool bDate;
        public bool Ruhezustand;   // Attribut -h   --> für Ruhezustand (energiesparen)
        public bool Force;        // Atributt -f      --> für alle Laufenden Programme sofort abbrechen
        public bool Neuestart;    // Atributt -r      --> für Neustart
        public bool Kommentar;    // Atributt -c      --> ob ein Kommentar angezeigt werden soll
        public bool bStopRunterfahren;     //Atributt -a -->bricht Herunterfahren ab, geht solange noch die Zeit runtertickt
        public bool Time;                 //Atributt -t 30  --> Zeitperiode bis Heruntergefahren wird
        public string Times;               //Atributt nach -t die Zeitangabe
        public string Komentar;   // Atributt -c "Komentar text bis 512 Zeichen, was angezeigt wird beim Herunterfahren"


        public DateTime Shutdowntime;
      
        
        //public  DateTime dtShutdowntime
        //{
        //    get
        //    {
        //       // return Shutdowntime;
        //    }

        //    set
        //    {
        //        Shutdowntime = dtShutdowntime;
        //    }

        //}


        //public DateTime dtShutdowntime
        //{
        //    get
        //    {
        //        return Shutdowntime;
        //    }

        //    set
        //    {
        //        Shutdowntime = dtShutdowntime;
        //    }

        //}
        //public bool bRuhezustand
        //{
        //    get
        //    {
        //        return Ruhezustand;
        //    }

        //    set
        //    {
        //        Ruhezustand = bRuhezustand;
        //    }

        //}
        //public bool bForce
        //{
        //    get
        //    {
        //        return Force;
        //    }

        //    set
        //    {
        //        Force = bForce;
        //    }

        //}
        //public bool bNeuestart
        //{
        //    get
        //    {
        //        return Neuestart;
        //    }

        //    set
        //    {
        //        Neuestart = bNeuestart;
        //    }

        //}
        //public bool bTime
        //{
        //    get
        //    {
        //        return Time;
        //    }

        //    set
        //    {
        //        Time = bTime;
        //    }

        //}

        //public string sTimes
        //{
        //    get
        //    {
        //        return Times;
        //    }

        //    set
        //    {
        //        Times = sTimes;
        //    }

        //}
        //public string sKomentar
        //{
        //    get
        //    {
        //        return Komentar;
        //    }

        //    set
        //    {
        //        Komentar = sKomentar;
        //    }

        //}

        //public bool bKommentar
        //{
        //    get
        //    {
        //        return Kommentar;
        //    }

        //    set
        //    {
        //        Kommentar = bKommentar;
        //    }

        //}
        private void ini_Dispatchertimer()
        {

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            dispatcherTimer.Tick += new EventHandler(timer_tick);

            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();


        }
        private void timer_tick(object sender, EventArgs e)
        {
            if (timecompare(Shutdowntime))
            {
            }
          // return true;
        }
        private bool timecompare(DateTime dtshutdowntime)
        {
            if (bDate )
            {
                if (string.Compare(DateTime.Now.Hour.ToString(), dtshutdowntime.Hour.ToString()) == 0 && string.Compare(DateTime.Now.Minute.ToString(), dtshutdowntime.Minute.ToString()) == 0 && string.Compare(DateTime.Now.Year.ToString(), dtshutdowntime.Year.ToString()) == 0 && string.Compare(DateTime.Now.Month.ToString(), dtshutdowntime.Month.ToString()) == 0 && string.Compare(DateTime.Now.Day.ToString(), dtshutdowntime.Day.ToString()) == 0)
                {
                     Shutdown();
                }
            }
            else
            {
                if (string.Compare(DateTime.Now.Hour.ToString(), dtshutdowntime.Hour.ToString()) == 0 && string.Compare(DateTime.Now.Minute.ToString(), dtshutdowntime.Minute.ToString()) == 0)
                //if (DateTime.Compare(DateTime.Now.Hour , shutdowntime.Hour ) == 0)
                {
                      Shutdown();
                }
            }

            return true;
        }

        public void Shutdown()
        {
            // MessageBox.Show("SHUTDOWN!!!");
            string sAtributte = "-i " ; // = ";

            if (Force || Neuestart || Ruhezustand)
            {

                if (Neuestart)
                {
                    sAtributte = "-r";
                }
                else if (Ruhezustand)
                {
                    sAtributte = "-h";
                }
                else
                {
                    sAtributte = "-s";
                }
                if (Time) sAtributte += " -t " + Times;


                if (Force) sAtributte += " -f";
               // if (Kommentar) sAtributte += " -c " + "\""  + Komentar + "\"";
              //  if (Kommentar) sAtributte += " -c " + Komentar;

                System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", sAtributte);


            }
            else
            {
                System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 10");
            
            }
        }


        #region öffentliche Methoden

        
        public bool Start_disTimer( bool bDatetoo)
        {
            try
            {
                bDate = true;
                ini_Dispatchertimer();
            }

            catch (Exception ex)
            {
             
                return false;
            }
 
            return true;
        }
        public bool Start_disTimer()
        {
            try
            {
                ini_Dispatchertimer();
            }

            catch (Exception ex)
            {

                return false;
            }




            return false;
        }

        #endregion

    }
}
