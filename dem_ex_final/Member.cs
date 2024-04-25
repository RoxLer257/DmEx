using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace dem_ex_final
{
    public class Member : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Member(string  _login, string _password) 
        {
            this._login = _login;
            this._password = _password;
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public enum UserRole
        {
            Admin,
            User
        }

        private UserRole _role;
        public UserRole Role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged("Role"); }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

    public class MemberList : INotifyPropertyChanged
    {
        public ObservableCollection<Member> members {  get; set; }

        public MemberList()
        {
            members = new ObservableCollection<Member>()
            {
                new Member("admin", "admin"),
                new Member("test", "test")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class RoleToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is Member.UserRole role && parameter is Member.UserRole targetRole)
            {
                return role == targetRole ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
