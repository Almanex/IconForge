using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SnapIcon;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? _window;
    
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    private static extern int MessageBoxW(IntPtr hWnd, string text, string caption, uint type);

    private static void LogAndShowException(Exception ex, string context)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string logPath = System.IO.Path.Combine(desktopPath, "SnapIcon_Crash_Log.txt");
        string message = $"Context: {context}\nException: {ex.GetType().Name}\nMessage: {ex.Message}\nStackTrace:\n{ex.StackTrace}";
        if (ex.InnerException != null)
        {
            message += $"\n\nInner Exception: {ex.InnerException.GetType().Name}\nMessage: {ex.InnerException.Message}\nStackTrace:\n{ex.InnerException.StackTrace}";
        }
        try
        {
            System.IO.File.WriteAllText(logPath, message);
        }
        catch {}

        MessageBoxW(IntPtr.Zero, $"{message}\n\nThis crash report was also saved to your Desktop as 'SnapIcon_Crash_Log.txt'.", "SnapIcon Startup Crash", 0x10);
    }

    public App()
    {
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogAndShowException(ex, "AppDomain Unhandled Exception");
            }
        };

        try
        {
            Microsoft.Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "";
        }
        catch { }

        try
        {
            EnsureResourcesPriExtracted();
        }
        catch (Exception ex)
        {
            LogAndShowException(ex, "EnsureResourcesPriExtracted");
        }

        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            LogAndShowException(ex, "InitializeComponent");
        }
    }

    private static bool IsPackaged()
    {
        try
        {
            return Windows.ApplicationModel.Package.Current != null;
        }
        catch
        {
            return false;
        }
    }

    private static void EnsureResourcesPriExtracted()
    {
        if (IsPackaged())
        {
            return;
        }

        try
        {
            string baseDir = System.AppContext.BaseDirectory;
            string targetPriPath = System.IO.Path.Combine(baseDir, "resources.pri");
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName ?? "SnapIcon");
            string exeNamePriPath = System.IO.Path.Combine(baseDir, $"{processName}.pri");

            if (System.IO.File.Exists(targetPriPath) && System.IO.File.Exists(exeNamePriPath))
            {
                return;
            }

            // 1. Get the directory where single-file bundle extracted native assemblies
            string? tempExtractDir = System.IO.Path.GetDirectoryName(typeof(Microsoft.UI.Xaml.Application).Assembly.Location);
            if (!string.IsNullOrEmpty(tempExtractDir))
            {
                string sourcePri = System.IO.Path.Combine(tempExtractDir, "resources.pri");
                if (!System.IO.File.Exists(sourcePri))
                {
                    sourcePri = System.IO.Path.Combine(tempExtractDir, "SnapIcon.pri");
                }

                if (System.IO.File.Exists(sourcePri))
                {
                    if (!System.IO.File.Exists(targetPriPath))
                    {
                        System.IO.File.Copy(sourcePri, targetPriPath, true);
                    }
                    if (!System.IO.File.Exists(exeNamePriPath))
                    {
                        System.IO.File.Copy(sourcePri, exeNamePriPath, true);
                    }
                    return;
                }
            }

            // 2. Try Embedded Resource in Assembly manifest
            var asm = typeof(App).Assembly;
            string[] resourceNames = asm.GetManifestResourceNames();
            foreach (var rName in resourceNames)
            {
                if (rName.EndsWith(".pri", System.StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = asm.GetManifestResourceStream(rName))
                    {
                        if (stream != null)
                        {
                            using (var fs = System.IO.File.Create(targetPriPath))
                            {
                                stream.CopyTo(fs);
                            }
                            try { System.IO.File.Copy(targetPriPath, exeNamePriPath, true); } catch { }
                            return;
                        }
                    }
                }
            }
        }
        catch
        {
            // Ignore if directory is read-only
        }
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        _window = new MainWindow();
        _window.Activate();
    }
}
