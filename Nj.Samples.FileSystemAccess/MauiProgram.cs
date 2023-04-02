using Microsoft.Extensions.Logging;
using Nj.Samples.FileDisclaimer.Abstractions;
using Nj.Samples.FileSystemAccess.Abstractions;
using Nj.Samples.FileSystemAccess.Services;

namespace Nj.Samples.FileSystemAccess;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

#if WINDOWS
        builder.Services.AddTransient<IFolderPicker, Platforms.Windows.DnjFolderPicker>();
#endif

        builder.Services.AddTransient<IFileSystemAccessVm, FileSystemAccessVm>();

        return builder.Build();
    }
}
