using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UnrealLauncher
{
    public class RelayCommand : ICommand
    {
        Action<object?> execute = null;
        Func<object, bool> canExecute = null;

        public event EventHandler? CanExecuteChanged // plus propre pour les events intégrés (bouton ) et on a accès au commandManager pour gérer les ajouts/ retraits de commande
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object?> _execute, Func<object, bool> _canExecute = null)
        {
            execute = _execute;
            canExecute = _canExecute;
        }


        public bool CanExecute(object? _parameter)
        {
            return canExecute == null || canExecute(_parameter);
        }

        public void Execute(object? _parameter)
        {
            execute?.Invoke(_parameter);
        }
    }
}
