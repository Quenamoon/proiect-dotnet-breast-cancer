using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ML;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ModelTrainer.Train();
                ModelLoader.Load();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine("[ML Model Trainer Error] Please Debug!");
                System.Console.WriteLine(e.ToString());
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}