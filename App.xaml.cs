using System.Windows;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using Niuniumama.DB;

namespace Niuniumama
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App:Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // 配置服务
            ServiceProvider = DB.ServiceProviderConfig.ConfigureServices();
            // 获取数据库服务
            var databaseService = ServiceProvider.GetRequiredService<MySqlDatabase>();
            
            // 测试数据库连接
            bool isConnected = await TestDatabaseConnectionAsync(databaseService);
            if (isConnected)
            {
                Console.WriteLine("连接数据库成功");
            }
            else
            {
                Console.WriteLine("连接数据库失败");
            }
            
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
        
        private async Task<bool> TestDatabaseConnectionAsync(MySqlDatabase database)
        {
            try
            {
                await database.OpenConnectionAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"数据库连接失败: {ex.Message}");
                return false;
            }
            finally
            {
                await database.CloseConnectionAsync();
            }
        }
    }
}