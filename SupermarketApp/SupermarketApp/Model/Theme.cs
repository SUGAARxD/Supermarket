
using SupermarketApp.ViewModel;

namespace SupermarketApp.Model
{
    public class Theme : BaseNotify
    {

        public Theme()
        {
        }

        #region Properties and members

        private string _windowBackgroundColor;
        public string WindowBackgroundColor
        {
            get => _windowBackgroundColor;
            set
            {
                _windowBackgroundColor = value;
                NotifyPropertyChanged(nameof(WindowBackgroundColor));
            }
        }

        private string _buttonBackgroundColor;
        public string ButtonBackgroundColor
        {
            get => _buttonBackgroundColor;
            set
            {
                _buttonBackgroundColor = value;
                NotifyPropertyChanged(nameof(ButtonBackgroundColor));
            }
        }

        private string _buttonBorderColor;
        public string BorderColor
        {
            get => _buttonBorderColor;
            set
            {
                _buttonBorderColor = value;
                NotifyPropertyChanged(nameof(BorderColor));
            }
        }

        #endregion

    }
}
