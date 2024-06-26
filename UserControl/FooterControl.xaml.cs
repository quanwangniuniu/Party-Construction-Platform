using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Niuniumama.UserControl
{
    public partial class FooterControl : System.Windows.Controls.UserControl
    {
        public FooterControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void OpenFacebook(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.facebook.com");
        }

        private void OpenTwitter(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.twitter.com");
        }

        private void OpenLinkedIn(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.linkedin.com");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Unable to open link: {ex.Message}");
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }
    }
}