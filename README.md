[ English ](README.md) • [ Русский ](README_RU.md) • [ Deutsch ](README_DE.md)

# IconForge Native icon generator for Windows 11

**IconForge** is a lightweight native Windows application (utility) developed on the **WinUI 3 (Windows App SDK)** framework and C#. It is designed for batch generation of icon sets for Windows (`.ico`, `Assets`) and Android (`Adaptive Icons`) from a single source image (PNG or SVG format).
## Application interface
---

## Main features

### Generating icon packs
* **Windows (Classic .ico):**
 * Build a multi-format `.ico` file containing resolutions: `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128`, `256x256` pixels.
 * **Micro-sharping:** For small sizes (16-48px), a special contour sharpening filter is automatically applied so that the icon does not become blurry in Explorer.
* **Windows Modern Assets (PNG):**
 * Export individual images for the manifest of modern Windows applications (`Square44x44Logo`, `Square150x150Logo`, `StoreLogo`) at all system scales: `scale-100`, `scale-125`, `scale-150`, `scale-200`, `scale-400`.
* **Android (Adaptive & Legacy Icons):**
 * Layer separation: the logo is automatically positioned inside the safe-zone 72dp of the **Foreground.png** layer, and the **Background.png** layer is filled with the selected color or texture file.
 * Export by project folder structure (`mipmap-mdpi` to `mipmap-xxxhdpi`).
 * Generate a round **Legacy icon** (`ic_launcher.png`) by masking and layering.
 * Export promo icon for Google Play Console in size `512x512` pixels.

### Modern Windows 11 interface (UI/UX)
* Using the system translucent material **Mica Alt** (adapts to desktop wallpaper).
* Full support for Windows 11 system Dark/Light theme.
* Interactive **Drag-and-Drop** zone with dynamic border color changes and built-in preview for PNG/SVG files.
* Quick palettes (swatches) for choosing the background color of an Android icon.

### ️ System Integration (Shell Integration)
* **Explorer context menu:** Option to embed the *"Generate icons in IconForge"* item directly into the Windows Explorer menu when you right-click on PNG/SVG. Registration occurs locally in the `HKEY_CURRENT_USER` hive and **does not require administrator rights (UAC)**.
* **Toast Notifications:** When the app is finished, it sends a native Windows 11 toast notification with an interactive Open Folder button.

---

## Technology stack
* **Language:** C# (.NET 8.0)
* **UI platform:** WinUI 3 (Windows App SDK 2.2.0)
* **Graphics:** SkiaSharp (Lanczos3 resize and filtering) + Svg.Skia (rendering vector graphics to raster).
* **Architectural type:** Unpackaged Self-Contained (the application comes with all libraries and runs without the need for a global installation of Windows App Runtime on the user's computer).

---

## File export structure

After generation, the following directory structure is created in the selected folder:

```text
[Папка_Назначения]/
├── Windows/
│   ├── app_icon.ico
│   └── Assets/
│       ├── Square44x44Logo.scale-100.png
│       ├── Square44x44Logo.scale-200.png
│       └── ... (все логотипы во всех масштабах)
└── Android/
    ├── play_store_512.png
    └── res/
        ├── mipmap-mdpi/
        │   ├── ic_launcher.png
        │   ├── ic_launcher_background.png
        │   └── ic_launcher_foreground.png
        └── mipmap-xxxhdpi/ ...
```

---

## How to build and run

### Requirements
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later.

###Building and running from the console
1. Clone the repository:
   ```bash
   git clone https://github.com/Almanex/icoboo.git
   cd icoboo
   ```
2. Compile the project:
   ```bash
   dotnet build
   ```
3. Launch the application:
   ```bash
   dotnet run
   ```

### Publishing (Self-Contained EXE)
To generate a single executable package (all dependencies will be copied to the `publish` folder):
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```
After this, the finished program can be run on any computer with Windows 10/11 without first installing any libraries.