using System;
using System.IO;
using System.Text.Json;

namespace SecondBraine.Logic
{
    /// <summary>
    /// Класс для сохранения и загрузки плана в JSON формате.
    /// </summary>
    public class PlanStorage
    {
        private string _filePath = "plan.json";

        public PlanStorage(string filePath = "plan.json") 
        {
            _filePath = filePath;
        }

        
        /// <summary>
        /// Сохраняет план в JSON файл.
        /// </summary>
        /// <param name="planData">Объект плана для сохранения.</param>
        public void SavePlan(PlanData planData)
        {
            try
            {
                string json = JsonSerializer.Serialize(planData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении плана: {ex.Message}");
            }
        }

        /// <summary>
        /// Загружает план из JSON файла.
        /// </summary>
        /// <returns>Объект плана, если файл существует; иначе null.</returns>
        public PlanData LoadPlan()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<PlanData>(json);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке плана: {ex.Message}");
                return null;
            }
        }
    }
}
