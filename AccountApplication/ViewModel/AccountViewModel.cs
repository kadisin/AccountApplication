using AccountApplication.Database;
using AccountApplication.Model;
using AccountApplication.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Configuration;

namespace AccountApplication.ViewModel
{
    internal class AccountViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Account _account;

        public Account SelectedAccount
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(SelectedAccount));
            }
        }

        private ObservableCollection<Account> _accountList;

        public ObservableCollection<Account> AccountList
        {
            get { return _accountList; }
            set
            {
                _accountList = value;
                OnPropertyChanged(nameof(AccountList));
            }
        }
        private string _newAccountName;
        public string NewAccountName
        {
            get { return _newAccountName; }
            set
            {
                _newAccountName = value;
                OnPropertyChanged(nameof(NewAccountName));
            }
        }
        private string _newAccountLogin;
        public string NewAccountLogin
        {
            get { return _newAccountLogin; }
            set
            {
                _newAccountLogin = value;
                OnPropertyChanged(NewAccountLogin);
            }
        }
        private string _newAccountPassword;
        public string NewAccountPassword
        {
            get { return _newAccountPassword; }
            set
            {
                _newAccountPassword = value;
                OnPropertyChanged(NewAccountPassword);
            }
        }



        private DatabaseContext _databaseContext;

        public AccountViewModel()
        {
            _databaseContext = new DatabaseContext();
            ReloadAccountData();
            DeleteAccountCommand = new Command((s) => true, DeleteAccount);
            UpdateSelectedAccountCommand = new Command((s) => true, UpdateDataSelectedAccount);
            AddAccountCommand = new Command((s) => true, AddAccount);
            UpdateAccountCommand = new Command((s) => true, UpdateAccount);
        }

        private void ReloadAccountData()
        {

            var accounts = _databaseContext.GetAccounts();
            AccountList = accounts;

        }

       protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddAccount(object obj)
        {
            var account = Account.CreateNewAccount(NewAccountName, NewAccountLogin, NewAccountPassword);
            var accounts = _databaseContext.AddAccount(account);
            AccountList = accounts;
        }


        private void DeleteAccount(object obj)
        {
            var account = obj as Account;
            var accounts = _databaseContext.DeleteAccount(account);
            AccountList = accounts;
        }

        private void UpdateDataSelectedAccount(object obj)

        {
            SelectedAccount = obj as Account;
        }


        private void UpdateAccount(object obj)
        {
            var accounts = _databaseContext.UpdateAccount(SelectedAccount);
            AccountList = accounts;
        }

        public ICommand DeleteAccountCommand { get; set; }
        public ICommand UpdateSelectedAccountCommand { get; set; }
        
        public ICommand AddAccountCommand { get; set; }

        public ICommand UpdateAccountCommand { get; set; }

    }

    class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        Action<object> MethodExecute;
        Func<object,bool> MethodCanExecute;

        public Command(Func<object,bool> methodCanExecute, Action<object> methodExecute)
        {
            MethodExecute = methodExecute;
            MethodCanExecute = methodCanExecute;
        }

        public bool CanExecute(object? parameter)
        {
            MethodCanExecute(parameter);
            return true;
        }

        public void Execute(object? parameter)
        {
            MethodExecute(parameter);
        }
    }
}


