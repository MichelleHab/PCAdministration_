using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading; // Обязательно для DispatcherTimer

namespace PCAdministration_
{
    public partial class MainWindow : Window
    {
        // Переменные для автотеста
        private DispatcherTimer _testTimer;
        private double _currentPercentage = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Запуск циклического автотеста
            StartAutoTest();
        }

        private void StartAutoTest()
        {
            _testTimer = new DispatcherTimer();
            // Интервал обновления — каждые 30 миллисекунд (плавная анимация)
            _testTimer.Interval = TimeSpan.FromMilliseconds(30);
            _testTimer.Tick += TestTimer_Tick;
            _testTimer.Start();
        }

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            // Увеличиваем значение. Шаг 0.5 дает плавный ход
            _currentPercentage += 0.5;

            // Если дошли до конца, сбрасываем в 0 и бежим по кругу заново
            if (_currentPercentage > 100)
            {
                _currentPercentage = 0;
            }

            // Вызываем ваш метод отрисовки
            SetSpeedProgress(_currentPercentage);
        }

        public void SetSpeedProgress(double percentage)
        {
            // 1. Ограничиваем и корректируем значение
            percentage = Math.Max(0, Math.Min(100, percentage));

            if (percentage >= 100) percentage = 99.99;
            if (percentage < 0) percentage = 0;

            // 2. Выводим текст (округляя до целого)
            if (PCS != null)
            {
                PCS.Text = $"{percentage:0} / 100";
            }

            // 3. ИСПРАВЛЕНО: Меняем цвет через ProgressPath (а не через конфликтующий Progress)
            if (ProgressPath != null)
            {
                if (percentage < 10)
                {
                    ProgressPath.Stroke = Brushes.Red;
                }
                else if (percentage < 50)
                {
                    ProgressPath.Stroke = Brushes.YellowGreen;
                }
                else
                {
                    ProgressPath.Stroke = Brushes.LightSeaGreen;
                }
            }

            // 4. Математика расчета полукруга (от левого нижнего угла к правому нижнему)
            double angle = Math.PI - ((percentage / 100.0) * Math.PI);

            // Центр и радиус подогнаны под координаты Data="M 15,90 A 45,45..." в XAML
            double centerX = 60;
            double centerY = 90;
            double radius = 45;

            double nextX = centerX + radius * Math.Cos(angle);
            double nextY = centerY - radius * Math.Sin(angle);

            // 5. Применяем новые координаты дуги
            if (ProgressArc != null)
            {
             //  ProgressArc.IsLargeArc = percentage > 50;
                ProgressArc.Point = new Point(nextX, nextY);
            }
        }
    }
}
