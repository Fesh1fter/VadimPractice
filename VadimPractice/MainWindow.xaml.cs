using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace VadimPractice
{
    public partial class MainWindow : Window
    {
        List<Request> requests = new List<Request>();
        private object selectedListItem;

        public MainWindow(string user)
        {
            InitializeComponent();

            string currentuser = user;

            if (currentuser == "Admin")
            {
                butAdd.Visibility = Visibility.Visible;
                butDel.Visibility = Visibility.Visible;
                deviceBox.Visibility = Visibility.Visible;
                reasonBox.Visibility = Visibility.Visible;
                bNameBox.Visibility = Visibility.Visible;
                statusBox.Visibility = Visibility.Visible;
                butEdit.Visibility = Visibility.Visible;
                deviceD.Visibility = Visibility.Visible;
                reasonD.Visibility = Visibility.Visible;
                fioD.Visibility = Visibility.Visible;
                statusD.Visibility = Visibility.Visible;
            }
            else if(currentuser != "Admin")
            {
                butAdd.Visibility = Visibility.Hidden;
                butDel.Visibility = Visibility.Hidden;
                deviceBox.Visibility = Visibility.Hidden;
                reasonBox.Visibility = Visibility.Hidden;
                bNameBox.Visibility = Visibility.Hidden;
                statusBox.Visibility = Visibility.Hidden;
                butEdit.Visibility = Visibility.Hidden;
                deviceD.Visibility = Visibility.Hidden;
                reasonD.Visibility = Visibility.Hidden;
                fioD.Visibility = Visibility.Hidden;
                statusD.Visibility = Visibility.Hidden;
            }
            // Добавляем тестовые заявки
            requests.Add(new Request(DateTime.Now, "Компьютер", "Не включается", "Иванов Иван", "В обработке", ""));
            requests.Add(new Request(DateTime.Now, "Принтер", "Не печатает", "Петров Петр", "В процессе выполнения", ""));
            requests.Add(new Request(DateTime.Now, "Монитор", "Битый экран", "Сидоров Сидор", "Завершена", ""));

            // Отображаем все заявки при запуске программы
            DisplayRequests(requests);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchParameter = searchTextBox.Text;
            List<Request> searchResults;

            if (string.IsNullOrEmpty(searchParameter))
            {
                searchResults = requests;
            }
            else
            {
                searchResults = requests.Where(req =>
                    req.DateAdded.ToString().Contains(searchParameter) ||
                    req.EquipmentType.Contains(searchParameter) ||
                    req.IssueType.Contains(searchParameter) ||
                    req.ClientName.Contains(searchParameter) ||
                    req.Status.Contains(searchParameter)
                ).ToList();
            }

            // Очищаем предыдущие результаты поиска
            resultsListBox.Items.Clear();

            // Выводим результаты поиска в ListBox
            DisplayRequests(searchResults);
        }

        private void DisplayRequests(List<Request> requestList)
        {
            foreach (var result in requestList)
            {
                resultsListBox.Items.Add(result.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resultsListBox.SelectedItem != null)
            {
                selectedListItem = resultsListBox.SelectedItem;
                Debug.Write(selectedListItem);
            }
        }

        private void butDel_Click(object sender, RoutedEventArgs e)
        {
            if (resultsListBox.SelectedItem != null)
            {
                resultsListBox.Items.Remove(resultsListBox.SelectedItem);
                MessageBox.Show("Заявка успешно удалена");
            }
        }

        private void butAdd_Click(object sender, RoutedEventArgs e)
        {
            bool ContainsDigits(string text)
            {
                foreach (char c in deviceBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        return true;
                    }
                }
                foreach (char c in reasonBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        return true;
                    }
                }
                foreach (char c in bNameBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        return true;
                    }
                }
                foreach (char c in statusBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        return true;
                    }
                }
                return false;
            }

            if (ContainsDigits(searchTextBox.Text))
            {
                MessageBox.Show("Неверно введены данные");
            }
            else
            {
                requests.Add(new Request(DateTime.Now, deviceBox.Text, reasonBox.Text, bNameBox.Text, statusBox.Text, ""));
                resultsListBox.Items.Clear();
                DisplayRequests(requests);

                MessageBox.Show("Заявка успешно добавлена");
            }
        }

        private void butEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (resultsListBox.SelectedItem != null)
            //{
            //    Request selectedRequest = resultsListBox.SelectedItem as Request;
            //    if (selectedRequest != null)
            //    {
            //        selectedRequest.currentWorker = "бебра";
            //        resultsListBox.Items.Refresh();
            //    }
            //}
        }

        private void deviceBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Request
    {
        public DateTime DateAdded { get; set; }
        public string EquipmentType { get; set; }
        public string IssueType { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public string currentWorker { get; set; }

        public Request(DateTime dateAdded, string equipmentType, string issueType, string clientName, string status, string worker)
        {
            DateAdded = dateAdded;
            EquipmentType = equipmentType;
            IssueType = issueType;
            ClientName = clientName;
            Status = status;
            currentWorker = worker;
        }

        public override string ToString()
        {
            return $"Дата добавления: {DateAdded}, Тип оборудования: {EquipmentType}, Тип неисправности: {IssueType}, ФИО клиента: {ClientName}, Статус заявки: {Status}, Текущий выполняющий: {currentWorker}";
        }
    }
}
