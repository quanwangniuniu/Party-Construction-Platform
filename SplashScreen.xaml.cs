using System.Windows;

namespace Niuniumama
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public void SetProgress(double value)
        {
            ProgressBar.Value = value;
        }
    }
}