using SecondBraine.Windows;
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

namespace SecondBraine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenDayPlanWindow(object sender, RoutedEventArgs e)
        {
            DayPlanWindow dayPlanWindow = new DayPlanWindow(PlanType.Day);
            dayPlanWindow.Show();
        }

        private void OpenMonthPlanWindow(object sender, RoutedEventArgs e)
        {
            DayPlanWindow monthPlanWindow = new DayPlanWindow(PlanType.Month);
            monthPlanWindow.Show();
        }

        private void OpenHalfYearPlanWindow(object sender, RoutedEventArgs e)
        {
            DayPlanWindow halfYearPlanWindow = new DayPlanWindow(PlanType.HalfY);
            halfYearPlanWindow.Show();
        }

        private void OpenYearPlanWindow(object sender, RoutedEventArgs e)
        {
            DayPlanWindow yearPlanWindow = new DayPlanWindow(PlanType.Year);
            yearPlanWindow.Show();
        }
    }
}
