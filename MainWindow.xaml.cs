using System.Windows;
using System.Windows.Navigation;

namespace Niuniumama
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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