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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private MemberList memberList;
        public Registration()
        {
            InitializeComponent();
            memberList = new MemberList();
            DataContext = memberList;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPass.Text == TxtPass1.Password)
            {
                Member member = new Member(TxtLogin.Text, TxtPass1.Password);
                memberList.members.Add(member);
                MessageBox.Show("Регистрация прошла успешно!");
                ClassFrame.frmObj.Navigate(new Main());
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate( new Authorization());
        }
    }
}
