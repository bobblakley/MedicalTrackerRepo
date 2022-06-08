using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MicroMvvm;


namespace MVVM_Medical_Tracker_GUI
{
    class TrackerData: ObservableObject
    {
        private Logger theLogger;
        const String AcetaminophenStr = "Acetaminophen";
        const String OxycotinStr = "Oxycotin";
        const String IbuprofenStr = "Ibuprofen";

        public TrackerData()
        {
            String ErrorString;
            theLogger = new Logger();

            _AcetaminophenCount = 0;
            _OxycotinCount = 0;
            _IbuprofenCount = 0;

            if (!theLogger.CreateNewLogFile(out ErrorString))
            {
                MessageBox.Show(ErrorString, "Log File Open Failed");
            }
        }
        private int _AcetaminophenCount;
        private int _OxycotinCount;
        private int _IbuprofenCount;
        public int AcetaminophenCount
        {
            get
            {
                return _AcetaminophenCount;
            }
            set
            {
                theLogger.LogCountChange(AcetaminophenStr, _AcetaminophenCount, value);
                _AcetaminophenCount = value;
                RaisePropertyChanged("AcetaminophenCount");
            }
        }

        public int OxycotinCount
        {
            get
            {
                return _OxycotinCount;
            }
            set
            {
                theLogger.LogCountChange(OxycotinStr, _OxycotinCount, value);
                _OxycotinCount = value;
                RaisePropertyChanged("OxycotinCount");
            }
        }

        public int IbuprofenCount
        {
            get
            {
                return _IbuprofenCount;
            }
            set
            {
                theLogger.LogCountChange(IbuprofenStr, _IbuprofenCount, value);
                _IbuprofenCount = value;
                RaisePropertyChanged("IbuprofenCount");
            }
        }
    }
}
