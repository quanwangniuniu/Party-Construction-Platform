using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Niuniumama
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 创建doubleAnimation实例
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };
            // 为窗口应用动画
            this.BeginAnimation(Window.OpacityProperty,fadeInAnimation);
        }
        private void NavigateToLearningArea(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LearningAreaPage());
        }

        private void NavigateToPartyDiscipline(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PartyDisciplinePage());
        }

        private void NavigateToBranchDynamics(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BranchDynamicsPage());
        }

        private void NavigateToForwardWithDiscipline(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ForwardWithDisciplinePage());
        }

        private void NavigateToPartyMemberStyle(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PartyMemberStylePage());
        }
    }
}