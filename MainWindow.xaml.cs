using System.Windows;

namespace Niuniumama
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowIntroductionButton_Click(object sender, RoutedEventArgs e)
        {
            IntroductionTextBlock.Text = "党建馆介绍内容更新：\n\n" +
                                         "党建馆是一个展示和传播党的历史、精神和成就的场所。这里有丰富的资料和互动展品，" +
                                         "帮助观众更好地理解党的发展历程和重大事件。";
        }
    }
}