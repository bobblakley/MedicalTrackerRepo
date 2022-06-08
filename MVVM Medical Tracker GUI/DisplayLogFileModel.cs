using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMvvm;

namespace MVVM_Medical_Tracker_GUI
{
    public class DisplayLogFileModel : ObservableObject
    {
        private String _LogData;
        public String LogData
        {
            get
            {
                return _LogData;
            }
            set
            {
                _LogData = value;
                RaisePropertyChanged("LogData");
            }
        }
    }
}
