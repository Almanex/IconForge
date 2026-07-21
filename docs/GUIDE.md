# IconForge User Guide

Welcome to the **IconForge** User Guide! This document provides detailed, step-by-step instructions on how to use all features of IconForge v1.0.2.

---

## Table of Contents
1. [Getting Started](#1-getting-started)
2. [Selecting & Loading Source Files](#2-selecting--loading-source-files)
3. [Image Filters & Color Correction](#3-image-filters--color-correction)
4. [Export Targets & Formats](#4-export-targets--formats)
5. [Live Pixel Preview Grid](#5-live-pixel-preview-grid)
6. [Reverse ICO Frame Extraction](#6-reverse-ico-frame-extraction)
7. [System & Explorer Integration](#7-system--explorer-integration)
8. [Standalone Single-File Deployment](#8-standalone-single-file-deployment)

---

## 1. Getting Started

IconForge is distributed as a single standalone executable file (`IconForge_v1.0.2_win-x64.exe`). It does not require any installation, administrative permissions, or background runtimes. Double-click the `.exe` file to launch the application.

---

## 2. Selecting & Loading Source Files

You can load a source artwork file using any of the following methods:
* **Drag-and-Drop:** Drag a file directly into the main drop area.
* **Browse Button:** Click the folder icon to select a file using the Windows File Picker.
* **Context Menu:** Right-click a PNG, SVG, or ICO file in Windows Explorer and select **"Generate icons in IconForge"**.

### Supported Input Formats
* **PNG (`.png`):** High-resolution raster images (1024x1024 recommended).
* **SVG (`.svg`):** Scalable vector graphics (rendered with lossless sharpness at all target sizes).
* **ICO (`.ico`):** Multi-layer ICO files (activates Reverse ICO Extraction mode).

---

## 3. Image Filters & Color Correction

The left configuration panel features real-time image filters:

* **Brightness Slider (-100 to +100):** Adjusts image luminance smoothly without clipping.
* **Contrast Slider (-100 to +100):** Modifies the contrast ratio of the artwork.
* **Corner Radius (%) (0 to 50%):** Rounds the corners of the generated icon.
* **Padding (%) (0 to 40%):** Shrinks the artwork inside the icon frame to create outer margin.
* **Grayscale Toggle:** Converts colors to monochrome grayscale.
* **Invert Colors Toggle:** Inverts image RGB values.
* **Drop Shadow Toggle:** Adds a soft, modern drop shadow around the artwork silhouette.
* **Color Tint (SVG Tint):** Enter a Hex color code (e.g. `#0078D4` or `#3DDC84`) to recolor vector or monochrome icons.

---

## 4. Export Targets & Formats

Check the desired export options in the right control panel:

* **Windows Classic `.ico`:** Creates a multi-resolution `app_icon.ico` container containing `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128`, and `256x256` pixel layers with micro-contour sharpening.
* **Windows Modern Assets:** Generates individual PNG logos for UWP/WinUI manifests (`Square44x44Logo`, `Square150x150Logo`, `StoreLogo`) across `scale-100` to `scale-400`.
* **Web & Favicon Pack:** Generates `favicon.ico`, `favicon-16x16.png`, `favicon-32x32.png`, `apple-touch-icon.png` (180x180), `android-chrome-192x192.png`, `android-chrome-512x512.png`, and a web manifest (`site.webmanifest`).
* **macOS App Icon (`.icns`):** Encodes an Apple binary `.icns` container file containing all macOS icon resolutions (`ic04` through `ic10`).
* **Android Adaptive & Legacy Icons:** Generates layered `Foreground.png` (safe zone 72dp) and `Background.png`, `mipmap` folders (`mdpi` to `xxxhdpi`), round legacy `ic_launcher.png`, and Google Play 512x512 promo artwork.

---

## 5. Live Pixel Preview Grid

The right panel features a multi-size live preview grid rendering artwork at `16x16`, `32x32`, `48x48`, and `256x256` pixel sizes in real time.

### Background Mode Switcher
Click the background toggle buttons in the preview grid header to test icon visibility against different environments:
1. **Transparent:** Displays a classic checkerboard pattern.
2. **Dark:** Displays a `#1F1F1F` dark background (simulating Windows 11 Dark Taskbar).
3. **Light:** Displays a `#F3F3F3` light background.
4. **Android/Project Background:** Displays the active background color selected in the Android background color settings.

---

## 6. Reverse ICO Frame Extraction

When an `.ico` file is loaded:
1. An **ICO Frame Extraction Card** appears above the main action button.
2. IconForge parses the binary directory and detects all embedded PNG/BMP resolutions inside the ICO file.
3. Clicking **"Extract All Frames to PNG"** unpacks each frame into separate PNG images inside the output folder.

---

## 7. System & Explorer Integration

* **Windows Explorer Context Menu:** Toggle the **"Windows Context Menu"** switch to register the shortcut under `HKEY_CURRENT_USER\Software\Classes\*\shell\IconForge`. No admin privileges are required.
* **Toast Notifications:** Upon completion, IconForge fires a native Windows 11 Toast Notification. Clicking the notification button opens the target export directory in File Explorer.

---

## 8. Standalone Single-File Deployment

IconForge v1.0.2 bundles all MRT Core resource tables (`resources.pri`) inside the executable. When launched, `App.xaml.cs` automatically extracts `resources.pri` to the local execution directory if not present. This allows `IconForge_v1.0.2_win-x64.exe` to run anywhere under any filename without companion folders or missing resource errors.
