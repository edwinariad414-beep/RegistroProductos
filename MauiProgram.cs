using Microsoft.Maui.Storage;
using RegistroProductos.Data;

namespace RegistroProductos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "productos.db3");
            builder.Services.AddSingleton<Database>(s => new Database(dbPath));

            return builder.Build();
        }
    }
}
