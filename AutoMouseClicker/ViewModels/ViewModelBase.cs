using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FrameApplication.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this DependencyObject has been updated.
        /// CallerMemberName obtain the method or property name of the caller to the method
        /// </summary>
        /// <param name="PropertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}