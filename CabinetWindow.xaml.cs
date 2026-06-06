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
using System.Xml.Linq;

namespace PCAdministration_
{
    /// <summary>
    /// Логика взаимодействия для CabinetWindow.xaml
    /// </summary>
    public partial class CabinetWindow : Window
    {
        public CabinetWindow()
        {
            InitializeComponent();
        }
        public int? _currentId = null;
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtFloor.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (string.IsNullOrWhiteSpace(TxtName.Text)) TxtName.Focus();
                else TxtFloor.Focus();
                return;
            }


            DialogResult = true; // Закрывает окно и возвращает успешный результат
            Close();
        }
        public CabinetWindow(int id, string name, string floor) : this()
        {
            Title = "Редактирование записи";
            _currentId = id;

            // Заполняем поля текущими данными
            TxtName.Text = name;
            TxtFloor.Text = floor;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
