using IomarPousada.Data.Interface;
using IomarPousada.Data.Repository;
using Microsoft.Extensions.Logging;

namespace IomarPousada;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();
        builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

        return builder.Build();
    }

}
