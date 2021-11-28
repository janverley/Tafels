using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tafels.Annotations;

namespace Tafels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int correctAnswers;
        private int left;
        private string message;
        private string name;
        private int progress;
        private int right;
        private int total;

        public ViewModel()
        {
            NextQuestionCommand = new DelegateCommand(NextQuestion, CanNextQuestion);
            NextGameCommand = new DelegateCommand(NextGame, o => true);

            Total = 10;
            Progress = 0;
            NextGame(null);
        }

        public ICommand NextGameCommand { get; }
        public ICommand NextQuestionCommand { get; }

        public int CorrectAnswers
        {
            get => correctAnswers;
            private set
            {
                if (correctAnswers == value)
                {
                    return;
                }

                correctAnswers = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (name == value)
                {
                    return;
                }

                name = value;
                OnPropertyChanged();
            }
        }

        public int Left
        {
            get => left;
            set
            {
                if (value == left)
                {
                    return;
                }

                left = value;
                OnPropertyChanged();
            }
        }

        public int Right
        {
            get => right;
            set
            {
                if (value == right)
                {
                    return;
                }

                right = value;
                OnPropertyChanged();
            }
        }

        public int Progress
        {
            get => progress;
            private set
            {
                if (progress == value)
                {
                    return;
                }

                progress = value;
                OnPropertyChanged();
            }
        }

        public int Total
        {
            get => total;
            private set
            {
                if (total == value)
                {
                    return;
                }

                total = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndTimestamp { get; private set; }

        public string Message
        {
            get => message;
            private set
            {
                if (message == value)
                {
                    return;
                }

                message = value;

                OnPropertyChanged();
            }
        }

        public DateTime StartTimestamp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CanNextQuestion(object arg)
        {
            return Progress < Total;
        }

        private void NextGame(object obj)
        {
            Message = "Spelen maar!";

            CreateQuestion();
            Progress = 0;
            StartTimestamp = DateTime.Now;
            EndTimestamp = DateTime.MinValue;
        }

        private void SetQuestionText()
        {
            QuestionText = $"{Left}  X  {Right}";
        }

        private void NextQuestion(object obj)
        {
            CreateQuestion();
            Progress++;
            CalculateScore();
        }

        private void CreateQuestion()
        {
            Left = NewRandomNumber(Left);
            Right = NewRandomNumber(Right);
            SetQuestionText();
        }

        private void CalculateScore()
        {
            if (Progress == Total)
            {
                EndTimestamp = DateTime.Now;
                var playtime = EndTimestamp - StartTimestamp;

                Message = $"Klaar! Je deed er {playtime.TotalSeconds:N0} seconden over.";
            }
        }


        private string questionText;

        public string QuestionText
        {
            get { return questionText; }
            private set
            {
                if (questionText == value)
                {
                    return;
                }
                questionText = value;
                OnPropertyChanged();
            }
        }
        
        private int NewRandomNumber(int currentValue, int minValue = 1, int maxValue = 10)
        {
            var rand = new Random();
            var result = rand.Next(minValue, maxValue);

            for (var j = 0; j < 10; j++)
            {
                if (result != currentValue)
                {
                    break;
                }

                result = rand.Next(minValue, maxValue);
            }

            return result;
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}