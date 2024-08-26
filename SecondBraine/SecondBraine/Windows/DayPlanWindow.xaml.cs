using System.Windows;

namespace SecondBraine.Windows
{
    /// <summary>
    /// Представляет окно для отображения и редактирования плана 
    /// </summary>
    public partial class DayPlanWindow : Window
    {

        TaskManipulation _taskManipulation;

        

        /// <summary>
        /// Создаёт новый экземпляр окна планирования
        /// </summary>
        /// <param name="title">Заголовок окна.</param>
        public DayPlanWindow(PlanType type)
        {
            InitializeComponent();
            _taskManipulation = new TaskManipulation(listBoxPlanItems, type); 
            DataContext = this;
            Title = type.ToString();
            _taskManipulation.LoadPlan();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Добавить задачу". 
        /// Разбивает текст плана на отдельные пункты и добавляет их в список задач.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _taskManipulation.AddTask(textBoxPlan.Text);
            UpdatePlansList();
            textBoxPlan.Clear();
        }

        /// <summary>
        /// Обновляет отображение списка задач в пользовательском интерфейсе.
        /// </summary>
        private void UpdatePlansList()
        {
            listBoxPlanItems.Items.Refresh();
            _taskManipulation.SavePlan();
        }

        /// <summary>
        /// Обработчик события изменения состояния CheckBox (отметка как выполненной).
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePlansList();
        }

        /// <summary>
        /// Обработчик события изменения состояния CheckBox (отметка как невыполненной).
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdatePlansList();
        }
    }
}
