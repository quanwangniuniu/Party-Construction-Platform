using System.Windows;
using System.Threading.Tasks;
using System;

namespace Niuniumama
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App:Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // 创建并显示启动窗口
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            
            // 加载过程
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    //更新进度条
                    Application.Current.Dispatcher.Invoke(() => splashScreen.SetProgress(i));
                    System.Threading.Thread.Sleep(50);
                }
            });
            
            // 加载完成后显示主窗口
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
            // 关闭启动窗口
            splashScreen.Close();
        }
    }
}