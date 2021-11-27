using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tafels.Annotations;

namespace Tafels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int total;
        private int correctAnswers;
        private int left;
        private string name;
        private int progress;
        private int right;

        public ViewModel()
        {
            OnNext = new DelegateCommand(GetNextValues, o => true);
            Total = 10;
            Progress = 0;
            OnVolgendSpel = new DelegateCommand(NextGame, o => true);
            
            GetNextValues(null);
        }

        public ICommand OnVolgendSpel { get; }
        public ICommand OnNext { get; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NextGame(object obj)
        {
            Progress = 0;
        }

        private void GetNextValues(object obj)
        {
            var rand = new Random();
            Left = rand.Next(0, 10);
            Right = rand.Next(0, 10);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}