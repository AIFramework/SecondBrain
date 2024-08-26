using SecondBraine.Windows;
using System;
using System.Collections.Generic;

namespace SecondBraine.Logic
{
    /// <summary>
    /// Класс для хранения данных плана.
    /// </summary>
    public class PlanData
    {
        /// <summary>
        /// Дата начала плана.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания плана.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Список задач, входящих в план.
        /// </summary>
        public List<PlanItem> Tasks { get; set; }
    }
}
