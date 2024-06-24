using System;
using Microsoft.Extensions.DependencyInjection;

namespace Niuniumama.DB
{
    public class ServiceProviderConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            
            // 注册服务
            serviceCollection.AddSingleton<MySqlDatabase>(provider =>
            {
                string connectionString = "server=localhost;user=root;database=niuniumama_db;port=3306;password=1111";
                return new MySqlDatabase(connectionString);
            });
            return serviceCollection.BuildServiceProvider();
        }
    }
}