using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using _01Piroh.Annotations;

namespace _01Piroh
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        private string _age;
        private string _western;
        private string _chinese;
        private bool _canExecute;
        private RelayCommand _ageCalc;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;


        public MainWindowViewModel(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
            CanExecute = true;
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged();}
        }

        public string Western
        {
            get { return _western; }
            set { _western = value; OnPropertyChanged(); }
        }

        public string Chinese
        {
            get { return _chinese; }
            set { _chinese = value; OnPropertyChanged();}
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set
            {
                _canExecute = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CountAge
        {
            get { return _ageCalc ?? (_ageCalc = new RelayCommand(AgeCalcImpl)); }
        }

        private async void AgeCalcImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_dateOfBirth);
                Thread.Sleep(3000);
            }));

            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Your date {_dateOfBirth} is not right!");

            else
            {
                if (_dateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
                 MessageBox.Show("Happy b-day to you!");

                Age = $"{StationManager.CurrentUser.Age}";
                Western = StationManager.CurrentUser.Western;
                Chinese = StationManager.CurrentUser.Chinese;
                _closeAction.Invoke();
            }

            CanExecute = true;

            _showLoaderAction.Invoke(false);
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


}
