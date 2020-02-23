using System.Windows;
using KMACSharp01Hak.Tools;
using KMACSharp01Hak.Tools.Managers;

namespace KMACSharp01Hak.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnProperyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnProperyChanged();
            }
        }
        #endregion

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
