using Notes.Persistence;

namespace Notes.WebAPI
{
    public class Program
    {
        //Initialization of application
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) //method of initialization of DB
            {
                var serviceProvider = scope.ServiceProvider; //for allow dependencies
                try
                {
                    var context = serviceProvider.GetRequiredService<NotesDbContext>(); //for receiving context
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occured while app initialization");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartupBase>();
                });
    }
}
