using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace _01Hak.Tools
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnProperyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(properyName));
        }
        #endregion
    }
}
