using System.Windows;
using System.Windows.Controls;

namespace Tafels
{
    public partial class MyProgressBar : UserControl
    {
        public static readonly DependencyProperty TotalProperty = DependencyProperty.Register(
            "Total", typeof(int), typeof(MyProgressBar), new PropertyMetadata(0));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof(int), typeof(MyProgressBar), new PropertyMetadata(0));

        public MyProgressBar()
        {
            InitializeComponent();
        }

        public int Total
        {
            get => (int)GetValue(TotalProperty);
            set => SetValue(TotalProperty, value);
        }

        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }
    }
}