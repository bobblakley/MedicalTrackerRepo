using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MicroMvvm;
using System.Windows;

namespace MVVM_Medical_Tracker_GUI
{
    public class DisplayLogFileViewModel : ObservableObject
    {
        public Action CloseAction { get; set; }
        private Logger theLogger;
        public DisplayLogFileViewModel()
        {
            theLogger = new Logger();
            model = new DisplayLogFileModel();
            Model.LogData = theLogger.ReadTheLogFile();
        }
        private DisplayLogFileModel model;
        public DisplayLogFileModel Model
        {
            get { return model; }
            set { model = value; }
        }
        public ICommand ExitProgram { get { return new RelayCommand(ExitProgramExecute, CanExitProgram); } }
        private void ExitProgramExecute()
        {
            CloseAction();
        }
        private bool CanExitProgram()
        {
            return true;
        }
    }
}
