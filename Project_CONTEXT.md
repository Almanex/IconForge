# Project Context: SnapIcon

## Core Application Overview
SnapIcon is a high-performance native Windows 11 utility written in C# and WinUI 3 (Windows App SDK 2.2) targeting .NET 10.0. It performs batch multi-platform icon package generation, reverse ICO layer extraction, live multi-size preview rendering, shape masking (Squircle, Circle, Teardrop, Rounded Rectangle), auto-cropping, and image filtering/recoloring from single source files (PNG, SVG, ICO).

## Architecture & Code Map
- **UI Platform:** WinUI 3, `MainPage.xaml`, `MainPage.xaml.cs`, `MainWindow.xaml`, `MainWindow.xaml.cs`.
- **Graphics Engine:** SkiaSharp (`SKBitmap`, `SKCanvas`, `SKColorFilter`, `SKPaint`), `Svg.Skia` for vector rendering.
- **Icon Processor (`Services/IconProcessor.cs`):**
  - `ProcessAsync(ProcessingOptions options, Action<string, double> onProgress)`: Primary asynchronous execution pipeline.
  - `ApplyFiltersAndStyling(...)`: Color matrices for Brightness, Contrast, Grayscale, Invert, SVG Tinting, Corner Radius %, Padding %, Shape Masks, Auto-Crop, and Drop Shadow.
  - `GenerateFaviconPackage(...)`: Generates `favicon.ico`, `apple-touch-icon.png`, `android-chrome-*.png`, and `site.webmanifest`.
  - `GenerateMacIcns(...)`: Encodes binary Apple `.icns` container files (`ic04` through `ic10`).
  - `ExtractIcoFrames(...)`: Parses binary ICO headers/directories and extracts PNG/BMP layers.
  - `LoadBaseBitmap(...)`: Decodes raster and vector SVG formats into 1024x1024 base Skia canvas.
- **Single-File PRI Extractor (`App.xaml.cs` & `SnapIcon.csproj`):**
  - Custom build target `BundlePriInSingleFile` in `.csproj` injects `SnapIcon.pri` into `@(ResolvedFileToPublish)` under relative path `resources.pri`.
  - `EnsureResourcesPriExtracted()` in `App()` extracts `resources.pri` at startup to `AppContext.BaseDirectory` before MRT Core initializes, enabling standalone execution under any EXE name.
- **Shell Integration (`Services/ShellIntegration.cs`):**
  - Manages Windows Explorer context menu shortcuts registered in `HKEY_CURRENT_USER\Software\Classes\*\shell\SnapIcon` using AQS query syntax `System.FileExtension:=.png OR System.FileExtension:=.svg OR System.FileExtension:=.ico`.
  - Dynamic UI logic: System Integration card is automatically collapsed (`SystemIntegrationCard.Visibility = Visibility.Collapsed`) when running inside the MSIX AppContainer to prevent non-functional registry operations.
- **Package Identity & Store Submission:**
  - Package Name: `AlmanexDev.SnapIcon`
  - Publisher: `CN=EAB645E2-6324-4940-918E-9C63AC494248` (`Almanex Dev`)
  - Package Family Name: `AlmanexDev.SnapIcon_e5fxmhvm59y00`
  - Status: **Submitted for Microsoft Store Certification**

## Supported Target Formats
1. **Windows Classic ICO:** Multi-resolution `.ico` container (`16x16` to `256x256`) with micro-contour sharpening for small resolutions.
2. **Windows Modern Assets:** UWP/WinUI manifest PNG logos (`Square44x44Logo`, `Square150x150Logo`, `StoreLogo`) at `scale-100` through `scale-400` and targetsize assets.
3. **Web & Favicon Pack:** `favicon.ico`, `favicon-16x16.png`, `favicon-32x32.png`, `apple-touch-icon.png`, `android-chrome-192x192.png`, `android-chrome-512x512.png`, and `site.webmanifest`.
4. **macOS ICNS:** Native Apple binary container `.icns`.
5. **Android Adaptive & Legacy:** Layered `Foreground.png` (safe-zone 72dp), `Background.png`, `mipmap` folders (`mdpi` to `xxxhdpi`), round legacy `ic_launcher.png`, and Google Play `512x512`.

## Localization
Supports English (`en-US`), Russian (`ru-RU`), and German (`de-DE`) managed through `.resw` resource files.
