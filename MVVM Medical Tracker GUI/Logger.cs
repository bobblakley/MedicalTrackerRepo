using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Security;

namespace MVVM_Medical_Tracker_GUI
{
    class Logger
    {
        public Logger()
        {
        }
        const String Filename = "..\\..\\DrugIncrementTest.log";
        const String DateTimeFormat = "{0:00}/{1:00}/{2:0000} {3:00}:{4:00}:{5:00}";
        public bool CreateNewLogFile(out String ErrorStr)
        {
            try
            {
                FileStream fs = null;
                fs = new FileStream(Filename, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    String TheDateString = FormatDateString(DateTime.Now);
                    String datastring = TheDateString + " START";
                    writer.WriteLine(datastring);
                }
                ErrorStr = "";
                return true;
            }
            catch (Exception ex)
            {
                ErrorStr = ex.Message;
                return false;
            }
        }
        private String FormatDateString(DateTime theDateTime)
        {
            String TheDateString = String.Format(DateTimeFormat, theDateTime.Month, theDateTime.Day, theDateTime.Year, theDateTime.Hour, theDateTime.Minute, theDateTime.Second);
            return TheDateString;
        }
        public bool LogCountChange(String DrugName, int PrevCount, int NewCount)
        {
            try
            {
                FileStream fs = null;
                fs = new FileStream(Filename, FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    String TheDateString = FormatDateString(DateTime.Now);
                    writer.WriteLine(String.Format("{0} {1} {2} {3}", TheDateString, DrugName, PrevCount, NewCount));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log Count IO Write Failed");
                return false;
            }
        }
        public bool LogReset()
        {
            try
            {
                FileStream fs = null;
                fs = new FileStream(Filename, FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    String TheDateString = FormatDateString(DateTime.Now);
                    writer.WriteLine(String.Format("{0} RESET", TheDateString));
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Log Reset IO Write Failed");
                return false;
            }
        }
        public String ReadTheLogFile()
        {
            String Buffer = "";
            try
            {
                Buffer = System.IO.File.ReadAllText(Filename);
                return Buffer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log File read Failed");
                return Buffer;
            }
        }
    }
}
