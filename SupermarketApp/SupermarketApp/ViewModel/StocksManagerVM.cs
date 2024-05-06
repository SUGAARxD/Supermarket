using SupermarketApp.Model;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class StocksManagerVM : BaseNotify
    {
        public StocksManagerVM()
        {
        }
        public StocksManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
        }

        #region Properties and members

        private Theme _myTheme;
        public Theme MyTheme
        {
            get => _myTheme;
            set
            {
                _myTheme = value;
                NotifyPropertyChanged(nameof(MyTheme));
            }
        }

        #endregion

        #region Commands

        private ICommand _Command;
        public ICommand Command
        {
            get
            {
                if (_Command == null)
                    _Command = new RelayCommand(G);
                return _Command;
            }
        }
        private void G(object parameter)
        {

        }

        #endregion

    }
}
