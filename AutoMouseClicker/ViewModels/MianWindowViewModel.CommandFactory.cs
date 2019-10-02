using FrameApplication.Commands;
using System.Windows.Input;

namespace FrameApplication.ViewModels
{
    public partial class MianWindowViewModel : ViewModelBase
    {
        private ICommand sampleCommand;
        public ICommand SampleCommand
        {
            get
            {
                if (sampleCommand == null)
                {
                    sampleCommand = new SampleCommand();
                }
                return sampleCommand;
            }
        }
    }
}
