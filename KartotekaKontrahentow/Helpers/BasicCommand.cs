using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KartotekaKontrahentow.Helpers
{
    public class BasicCommand : ICommand
    {
        private Action action;
        public event EventHandler CanExecuteChanged;

        public BasicCommand(Action _action)
        {
            action = _action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
