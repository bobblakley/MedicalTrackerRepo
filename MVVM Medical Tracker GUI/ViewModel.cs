using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MicroMvvm;

namespace MVVM_Medical_Tracker_GUI
{
    class ViewModel : ObservableObject
    {
        private TrackerData data;
        private DisplayLogFile theDisplayLogFileDialog;
        private Logger theLogger;
        public ViewModel()
        {
            theLogger = new Logger();
            data = new TrackerData();
        }
        public TrackerData Data
        {
            get { return data; }
            set { data = value; }
        }

        // Increment count by one command methods for Acetaminophen
        public ICommand IncAcetaminophenCount { get { return new RelayCommand(IncAcetaminophenExecute, CanIncAcetaminophenCountExecute); } }
        private void IncAcetaminophenExecute()
        {
            Data.AcetaminophenCount++;
        }
        private bool CanIncAcetaminophenCountExecute()
        {
            return true;
        }

        // Increment count by one command methods for Ibuprofen
        public ICommand IncIbuprofenCount { get { return new RelayCommand(IncIbuprofenExecute, CanIncIbuprofenCountExecute); } }
        private void IncIbuprofenExecute()
        {
            Data.IbuprofenCount++;
        }
        private bool CanIncIbuprofenCountExecute()
        {
            return true;
        }

        // Increment count by one command methods for Oxycotin
        public ICommand IncOxycotinCount { get { return new RelayCommand(IncOxycotinExecute, CanIncOxycotinCountExecute); } }
        private void IncOxycotinExecute()
        {
            Data.OxycotinCount++;
        }
        private bool CanIncOxycotinCountExecute()
        {
            return true;
        }

        // Handle Reset all counts command methods
        public ICommand DoResetAllCounts { get { return new RelayCommand(DoResetAllCountsExecute, CanDoResetAllCountsExecute); } }
        private void DoResetAllCountsExecute()
        {
            theLogger.LogReset();
            Data.OxycotinCount = 0;
            Data.AcetaminophenCount = 0;
            Data.IbuprofenCount = 0;
        }
        private bool CanDoResetAllCountsExecute()
        {
            return true;
        }

        // Handle Open Log File command
        public ICommand OpenLogFile { get { return new RelayCommand(OpenLogFileExecute, CanOpenLogFileExecute); } }
        private void OpenLogFileExecute()
        {
            theDisplayLogFileDialog = new DisplayLogFile();
            theDisplayLogFileDialog.ShowDialog();
        }
        private bool CanOpenLogFileExecute()
        {
            return true;
        }

        // Handle Exit command
        public ICommand ExitProgram { get { return new RelayCommand(ExitProgramExecute, CanExitProgram); } }
        private void ExitProgramExecute()
        {
            App.Current.Shutdown();
        }
        private bool CanExitProgram()
        {
            return true;
        }
    }
}
