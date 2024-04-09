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
using System.Windows.Shapes;

namespace VadimPractice
{
    /// <summary>
    /// Логика взаимодействия для passWordPage.xaml
    /// </summary>
    public partial class passWordPage : Window
    {
        public passWordPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordBox.Text;

            if (login == "test1" && password == "111")
            {
                MessageBox.Show("Успешный вход как test1");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (login == "test2" && password == "222")
            {
                MessageBox.Show("Успешный вход как test2");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (login == "test3" && password == "333")
            {
                MessageBox.Show("Успешный вход как test3");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
