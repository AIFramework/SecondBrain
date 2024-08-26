using SecondBraine.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SecondBraine.Windows
{
    public class TaskManipulation
    {

        private string _path;
        PlanStorage _planStorage;


        /// <summary>
        /// Дата начала плана.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания плана.
        /// </summary>
        public DateTime EndDate { get; set; }

        private List<PlanItem> PlanItems { get; set; } = new List<PlanItem>();

        private ListBox _listBoxPlanItems;

        /// <summary>
        /// Система для манипуляции планом
        /// </summary>
        /// <param name="planType">Тип плана</param>
        public TaskManipulation(ListBox listBoxPlanItems, PlanType planType = PlanType.Day)
        {
            _path = GetPath(planType);
            _planStorage = new PlanStorage(_path);
            _listBoxPlanItems = listBoxPlanItems;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            listBoxPlanItems.ItemsSource = PlanItems;
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="taskText">Текст задачи</param>
        public void AddTask(string taskText)
        {
            if (string.IsNullOrWhiteSpace(taskText))
            {
                MessageBox.Show("Пожалуйста, введите задачу.");
                return;
            }

            string[] planParts = taskText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var part in planParts)
                PlanItems.Add(new PlanItem { Text = part, IsCompleted = false });

        }

        public static void RemoveTask(string taskText)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сохранение плана
        /// </summary>
        public void SavePlan() 
        {
            PlanData plan = Convert();
            _planStorage.SavePlan(plan);
        }

        /// <summary>
        /// Загрузка плана
        /// </summary>
        public void LoadPlan() 
        {
            var data = _planStorage.LoadPlan();
            PlanItems = data.Tasks;
            _listBoxPlanItems.ItemsSource = PlanItems;
        }

        /// <summary>
        /// Конвертирует PlanItem и DateTime в PlanData
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public PlanData Convert() 
        { 
            PlanData data  =   new PlanData();

            data.StartDate =   StartDate;
            data.EndDate   =   EndDate;
            data.Tasks     =   PlanItems;
        
            return data;    
        }


        /// <summary>
        /// Отдает путь до файла с планом
        /// </summary>
        /// <returns></returns>
        public static string GetPath(PlanType type)
        {
            string directory = @"plan";
            string file = $@"{directory}\{type}.plan";

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!File.Exists(file)) File.Create(file);

            return file;
        }
    }

    public enum PlanType : byte 
    {
        /// <summary>
        /// День
        /// </summary>
        Day,
        /// <summary>
        /// Месяц
        /// </summary>
        Month,
        /// <summary>
        /// Полгода
        /// </summary>
        HalfY,
        /// <summary>
        /// Год
        /// </summary>
        Year,
    }
}
