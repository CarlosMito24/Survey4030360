using Survey4030360.Views;
using Survey4030360.Data;
using Microsoft.Extensions.Logging;

namespace Survey4030360
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<SurveysView>();
            builder.Services.AddTransient<SurveyDetailsView>();
            builder.Services.AddSingleton<SurveyItemDatabase>();

            return builder.Build();
        }
    }
}