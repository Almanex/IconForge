[README_RU](docs/README_RU.md) | [README_DE](docs/README_DE.md) | [README_EN](README.md) | [GUIDE_RU](docs/GUIDE_RU.md) | [GUIDE_DE](docs/GUIDE_DE.md) | [GUIDE_EN](docs/GUIDE.md)

# IconForge

*Native multi-format icon generator and image processing utility for Windows 11*

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows%2010%20%2F%2011-blue)](https://www.microsoft.com/windows)
[![Framework: .NET 10.0](https://img.shields.io/badge/Framework-.NET%2010.0-blue)](https://dotnet.microsoft.com/download)
[![UI: WinUI 3](https://img.shields.io/badge/UI-WinUI%203-blue)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Release: v1.0.4](https://img.shields.io/badge/Release-v1.0.4-brightgreen)](https://github.com/Almanex/IconForge/releases/tag/v1.0.4)

IconForge is a lightweight, native Windows 11 application built with C# and WinUI 3 (Windows App SDK) targeting .NET 10.0. Out of the box, it features complete tri-lingual support (English, Russian, German) and is designed for automated generation of icon packages for Windows (`.ico`, `Assets`), Web (`Favicon Pack`), macOS (`.icns`), and Android (`Adaptive Icons`) from single or multiple source images (PNG, SVG, or ICO).

For a detailed step-by-step walkthrough, see the [User Guide](docs/GUIDE.md).

---

## Key Features

### Multi-Platform Icon Generation

* **Windows (Classic .ico):**
  * Multi-resolution `.ico` container with sizes: `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128`, `256x256` pixels.
  * **Micro-sharpening:** Automatically applies an edge-sharpening contour filter for small resolutions (16-48px) to prevent blurriness in Windows Explorer.
* **Windows Modern Assets (PNG):**
  * Individual PNG assets for UWP/WinUI app manifest (`Square44x44Logo`, `Square150x150Logo`, `StoreLogo`) across all system display scale factors: `scale-100`, `scale-125`, `scale-150`, `scale-200`, `scale-400`.
* **Web & Favicon Pack:**
  * Complete web icon package including `favicon.ico`, `favicon-16x16.png`, `favicon-32x32.png`, `apple-touch-icon.png` (180x180), `android-chrome-192x192.png`, `android-chrome-512x512.png`, and an auto-generated `site.webmanifest`.
* **macOS App Icon (.icns):**
  * Native binary encoder generating Apple `.icns` containers with `ic04`, `ic05`, `ic06`, `ic07`, `ic08`, `ic09`, and `ic10` resolution blocks.
* **Android (Adaptive and Legacy Icons):**
  * Layer separation: places the source artwork within the safe zone (72dp) of `Foreground.png`, while `Background.png` is filled with a solid color or custom background image.
  * Mipmap folder tree generation (`mipmap-mdpi` through `mipmap-xxxhdpi`).
  * Round Legacy icon (`ic_launcher.png`) and Google Play Console `512x512` promo icon.

### Real-Time Filters, Shape Masks & Auto-Crop

* **Auto-Crop Transparent Margins:** High-performance unsafe pixel bounding box detection that automatically trims empty transparent outer padding before mask application.
* **Icon Shape Masks:** Instant vector shape masks: **Squircle** (iOS/Android smooth curves), **Circle** (100% vector circle), **Teardrop** (Android Adaptive Teardrop), and **Rounded Rectangle**.
* **Image Adjustments:** Real-time sliders for Brightness (-100 to +100) and Contrast (-100 to +100).
* **Corner Radius & Padding:** Adjustable corner rounding (0 to 50%) with 1:1 square canvas protection against oval distortion, and artwork padding (0 to 40%).
* **Visual Effects:** One-click Toggles for Grayscale, Color Inversion, and Drop Shadow.
* **SVG Tinting & Recolor:** Custom Hex color picker to tint vector and raster icons.

### Multi-Size Live Preview Grid & Zoom Control

* Simultaneous live preview rendering at standard pixel sizes: `16x16`, `32x32`, `48x48`, `256x256`.
* **1x / 2x Zoom Control:** Switch between native 1:1 physical pixel rendering mode and 2x magnified pixel view.
* **Background Mode Switcher:** Instant toggling between Transparent (checkerboard), Dark (#1F1F1F), Light (#F3F3F3), and Custom Project Background Color.

### Batch Processing & Reverse ICO Extraction

* **Batch Mode:** Select or drag-and-drop multiple PNG/SVG files to process entire icon sets in one click.
* **Reverse ICO Extraction:** Dragging or opening any `.ico` file automatically extracts all embedded PNG/BMP layers into standalone PNG files.

### Windows 11 Integration & Single-File Binary

* **Mica Alt & Dark/Light Theme:** Fluent Design visual material adapting dynamically to system theme.
* **Explorer Context Menu:** Right-click integration ("Generate icons in IconForge") registered under classic and modern Windows 11 menus.
* **Single Standalone Executable:** Fully bundled self-contained `.exe` (`IconForge.exe`). All resources are extracted automatically at startup.

---

## Technology Stack

| Component | Technology | Purpose |
| --- | --- | --- |
| Framework | C# (.NET 10.0) | `net10.0-windows10.0.26100.0` target |
| UI Framework | WinUI 3 | Windows App SDK 1.6 / 2.2 |
| Graphics Engine | SkiaSharp | Resampling (Lanczos3), filters, and color matrices |
| SVG Engine | Svg.Skia | High-precision vector rasterization |
| Packaging | Single-File Executable | Bundled unpackaged self-contained binary |

---

## Export File Structure

```text
[Destination_Directory]/
├── Windows/
│   ├── app_icon.ico
│   └── Assets/
│       ├── Square44x44Logo.scale-100.png
│       ├── Square44x44Logo.scale-200.png
│       └── ... (all scales)
├── Web/
│   ├── favicon.ico
│   ├── favicon-16x16.png
│   ├── favicon-32x32.png
│   ├── apple-touch-icon.png
│   ├── android-chrome-192x192.png
│   ├── android-chrome-512x512.png
│   └── site.webmanifest
├── macOS/
│   └── app_icon.icns
└── Android/
    ├── play_store_512.png
    └── res/
        ├── mipmap-mdpi/
        └── mipmap-xxxhdpi/
```

---

## Building and Running

### Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later.

### Console Build & Run

```powershell
git clone https://github.com/Almanex/icoboo.git
cd icoboo
dotnet build
dotnet run
```

### Standalone Single-File Release Build

```powershell
dotnet publish -c Release -r win-x64 --self-contained true
```
This produces a single executable `IconForge.exe` inside `bin/Release/.../publish/`. All MRT Core resource files (`resources.pri`) are bundled inside the `.exe`.

---

## License

Licensed under the [MIT License](LICENSE).
