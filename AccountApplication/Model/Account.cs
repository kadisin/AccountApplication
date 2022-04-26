using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccountApplication.Model
{
    public class Account : INotifyPropertyChanged
    {
        int _id;
        string _name;
        string _login;
        string _password;

        public int Id { get { return _id; } 
            set { 
                _id = value;
                OnPropertyChanged(nameof(Id));
            } 
        }
        public string Name { get { return _name; } 
            set { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }
        public string Login { get { return _login; } 
            set {
                _login = value;
                OnPropertyChanged(Login);
            } 
        }
        public string Password { get { return _password; } 
            set { 
                _password = value;
                OnPropertyChanged(Password);
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public static Account CreateNewAccount(string name, string login, string password)
        {
            //just for tests, in mvvm class i using connection to db so its hard to unittest methods...
            if(String.IsNullOrEmpty(login))
            {
                return null;
            }
            return new Account()
            {
                Name = name,
                Login = login,
                Password = password
            };
        }
        public override bool Equals(object? obj)
        {
            var otherAcconut = obj as Account;
            if (otherAcconut == null)
                return false;
            if (this.Login == otherAcconut.Login && this.Name == otherAcconut.Name && this.Password == otherAcconut.Password)
                return true;

            return base.Equals(obj);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
