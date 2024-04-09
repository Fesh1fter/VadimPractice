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

namespace VadimPractice
{
    public partial class MainWindow : Window
    {
        List<Request> requests = new List<Request>();

        public MainWindow()
        {
            InitializeComponent();
            // Добавляем тестовые заявки
            requests.Add(new Request(DateTime.Now, "Компьютер", "Не включается", "Иванов Иван", "В обработке"));
            requests.Add(new Request(DateTime.Now, "Принтер", "Не печатает", "Петров Петр", "В процессе выполнения"));
            requests.Add(new Request(DateTime.Now, "Монитор", "Битый экран", "Сидоров Сидор", "Завершена"));

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
    }

    public class Request
    {
        public DateTime DateAdded { get; set; }
        public string EquipmentType { get; set; }
        public string IssueType { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }

        public Request(DateTime dateAdded, string equipmentType, string issueType, string clientName, string status)
        {
            DateAdded = dateAdded;
            EquipmentType = equipmentType;
            IssueType = issueType;
            ClientName = clientName;
            Status = status;
        }

        public override string ToString()
        {
            return $"Дата добавления: {DateAdded}, Тип оборудования: {EquipmentType}, Тип неисправности: {IssueType}, ФИО клиента: {ClientName}, Статус заявки: {Status}";
        }
    }
}
