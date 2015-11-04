﻿using System;
using System.Windows.Input;

namespace BDSA2015.Lecture09.Universal.Models
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged(object sender)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(sender, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }


}
