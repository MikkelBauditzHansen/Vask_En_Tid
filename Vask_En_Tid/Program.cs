using Vask_En_Tid_Library.Service;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            // Hent connection string fra konfiguration
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Registrer repository og service
            builder.Services.AddScoped<IResidentRepository>(provider => new ResidentCollectionRepo(connectionString));
            builder.Services.AddScoped<ResidentService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
