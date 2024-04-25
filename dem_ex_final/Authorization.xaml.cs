using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dem_ex_final
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private MemberList memberList;

        public Authorization()
        {
            InitializeComponent();
            memberList = new MemberList();
            DataContext = memberList;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtLogin.Text;
            string password = TxtPass.Password;
            Member.UserRole userRole = Member.UserRole.User;
            if (login == "admin" && password == "admin")
            {
                userRole = Member.UserRole.Admin;
                MessageBox.Show("Авторизация успешна");
                ClassFrame.frmObj.Navigate(new Main());
            }
            else
            {
                bool isAuth = memberList.members.Any(m => m.Login == login && m.Password == password);
                if (isAuth)
                {
                    MessageBox.Show("Авторизация успешна");
                    ClassFrame.frmObj.Navigate(new Main());
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            foreach(var member in memberList.members)
            {
                if(member.Login == login)
                {
                    member.Role = userRole;
                    break;
                }
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new Registration());
        }
    }
}
