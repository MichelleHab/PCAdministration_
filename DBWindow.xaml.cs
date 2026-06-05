using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
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

namespace PCAdministration_
{
    /// <summary>
    /// Логика взаимодействия для DBWindow.xaml
    /// </summary>
    public partial class DBWindow : Window
    {
        public DBWindow()
        {
            InitializeComponent();
        }
        private void TabButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            DataTable tb;
            switch (clickedButton.Tag.ToString())
            {
                case "cabinet":
                    tb = Sql.Query("SELECT `name`, `floor` FROM `Answer_Book_problem`.`Cabinet` LIMIT 1000;");
                    break;
                case "pc":
                    tb = Sql.Query("SELECT `cabinet_id`, `pc_number`, `ip` FROM `Answer_Book_problem`.`PC` LIMIT 1000;");
                    break;
                case "problem":
                    tb = Sql.Query("SELECT `type`, `code`, `priority` FROM `Answer_Book_problem`.`Problem` LIMIT 1000;");
                    break;
                case "archive":
                    tb = Sql.Query("SELECT `master`, `problem_id`, `pc_id`, `status`, `solution_and_info` " +
                        "FROM `Answer_Book_problem`.`Archive` LIMIT 1000;");
                    break;
                    default:
                    return;
            }
            MainDataGrid.ItemsSource = tb.DefaultView;
        }

        // Действия правой панели
        private void Add_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Добавление записи");
        private void Print_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Печать таблицы");
        private void Edit_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Редактирование записи");
        private void Delete_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Удаление записи");

        private void MainDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
