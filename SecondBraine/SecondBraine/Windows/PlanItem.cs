using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace SecondBraine.Windows
{
    /// <summary>
    /// Представляет элемент плана, состоящий из текста и состояния выполнения.
    /// </summary>
    [Serializable]
    public class PlanItem : INotifyPropertyChanged
    {
        private bool isCompleted;
        private string text;
        private TextDecorationCollection textDecoration;
        private DateTime? completionDate;

        /// <summary>
        /// Текст, описывающий пункт плана.
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        /// <summary>
        /// Определяет, выполнен ли пункт плана.
        /// </summary>
        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    TextDecoration = isCompleted ? TextDecorations.Strikethrough : null;
                    CompletionDate = isCompleted ? DateTime.Now : (DateTime?)null;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        /// <summary>
        /// Декорация текста, применяемая при выполнении пункта плана (например, зачеркивание).
        /// </summary>
        [JsonIgnore]
        public TextDecorationCollection TextDecoration
        {
            get => textDecoration;
            set
            {
                if (textDecoration != value)
                {
                    textDecoration = value;
                    OnPropertyChanged(nameof(TextDecoration));
                }
            }
        }

        /// <summary>
        /// Дата завершения выполнения пункта плана. Null, если пункт не выполнен.
        /// </summary>
        public DateTime? CompletionDate
        {
            get => completionDate;
            private set
            {
                if (completionDate != value)
                {
                    completionDate = value;
                    OnPropertyChanged(nameof(CompletionDate));
                }
            }
        }

        /// <summary>
        /// Событие, возникающее при изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события PropertyChanged.
        /// </summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
