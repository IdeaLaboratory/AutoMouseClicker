using FrameApplication.ViewModels;
using System;
using System.Windows.Input;

namespace FrameApplication.Commands
{
    /// <summary>
    /// This command class is for a particular action.
    /// </summary>
    public class SampleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Specific condition which decide if the command can be executed or not
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var canExecute = (parameter as MianWindowViewModel)?.CanExecute;
            return canExecute == true;
        }

        /// <summary>
        /// Specific action to be executed
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            (parameter as MianWindowViewModel)?.Execute();
        }
    }
}