[ English ](README.md) • [ Русский ](README_RU.md) • [ Deutsch ](README_DE.md)

# Nativer Icon-Generator von IconForge für Windows 11

**IconForge** ist eine schlanke native Windows-Anwendung (Dienstprogramm), die auf dem **WinUI 3 (Windows App SDK)**-Framework und C# entwickelt wurde. Es ist für die Batch-Generierung von Symbolsätzen für Windows („.ico“, „Assets“) und Android („Adaptive Icons“) aus einem einzigen Quellbild (PNG- oder SVG-Format) konzipiert.
## Anwendungsschnittstelle
---

## Hauptmerkmale

### Generieren von Icon-Paketen
* **Windows (klassisches .ico):**
 * Erstellen Sie eine Multiformat-„.ico“-Datei mit den Auflösungen „16x16“, „24x24“, „32x32“, „48x48“, „64x64“, „128x128“, „256x256“ Pixel.
 * **Mikroschärfung:** Bei kleinen Größen (16–48 Pixel) wird automatisch ein spezieller Konturschärfungsfilter angewendet, damit das Symbol im Explorer nicht unscharf wird.
* **Windows Modern Assets (PNG):**
 * Exportieren Sie einzelne Bilder für das Manifest moderner Windows-Anwendungen („Square44x44Logo“, „Square150x150Logo“, „StoreLogo“) in allen Systemmaßstäben: „scale-100“, „scale-125“, „scale-150“, „scale-200“, „scale-400“.
* **Android (Adaptive & Legacy Icons):**
 * Ebenentrennung: Das Logo wird automatisch innerhalb der sicheren Zone von 72 dp der Ebene **Foreground.png** positioniert und die Ebene **Background.png** wird mit der ausgewählten Farb- oder Texturdatei gefüllt.
 * Export nach Projektordnerstruktur („mipmap-mdpi“ nach „mipmap-xxxhdpi“).
 * Erzeugen Sie durch Maskieren und Überlagern ein rundes **Legacy-Symbol** („ic_launcher.png“).
 * Promo-Symbol für die Google Play Console in der Größe „512 x 512“ Pixel exportieren.

### Moderne Windows 11-Oberfläche (UI/UX)
* Verwendung des systemtransparenten Materials **Mica Alt** (passt sich dem Desktop-Hintergrund an).
* Volle Unterstützung für das Dunkel/Hell-Design des Windows 11-Systems.
* Interaktive **Drag-and-Drop**-Zone mit dynamischen Änderungen der Randfarbe und integrierter Vorschau für PNG/SVG-Dateien.
* Schnellpaletten (Farbfelder) zum Auswählen der Hintergrundfarbe eines Android-Symbols.

### ️ Systemintegration (Shell-Integration)
* **Explorer-Kontextmenü:** Option zum Einbetten des Elements *"Symbole in IconForge generieren"* direkt in das Windows Explorer-Menü, wenn Sie mit der rechten Maustaste auf PNG/SVG klicken. Die Registrierung erfolgt lokal im Hive „HKEY_CURRENT_USER“ und **erfordert keine Administratorrechte (UAC)**.
* **Toastbenachrichtigungen:** Wenn die App fertig ist, sendet sie eine native Windows 11-Toastbenachrichtigung mit einer interaktiven Schaltfläche „Ordner öffnen“.

---

## Technologie-Stack
* **Sprache:** C# (.NET 8.0)
* **UI-Plattform:** WinUI 3 (Windows App SDK 2.2.0)
* **Grafiken:** SkiaSharp (Lanczos3-Größenänderung und Filterung) + Svg.Skia (Rendern von Vektorgrafiken in Raster).
* **Architekturtyp:** Unverpackt, eigenständig (die Anwendung wird mit allen Bibliotheken geliefert und läuft, ohne dass eine globale Installation von Windows App Runtime auf dem Computer des Benutzers erforderlich ist).

---

## Dateiexportstruktur

Nach der Generierung wird im ausgewählten Ordner folgende Verzeichnisstruktur erstellt:

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

## Wie man erstellt und ausführt

### Anforderungen
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) oder höher.

###Erstellen und Ausführen über die Konsole
1. Klonen Sie das Repository:
   ```bash
   git clone https://github.com/Almanex/icoboo.git
   cd icoboo
   ```
2. Kompilieren Sie das Projekt:
   ```bash
   dotnet build
   ```
3. Starten Sie die Anwendung:
   ```bash
   dotnet run
   ```

### Veröffentlichen (eigenständige EXE-Datei)
So generieren Sie ein einzelnes ausführbares Paket (alle Abhängigkeiten werden in den Ordner „publish“ kopiert):
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```
Danach kann das fertige Programm auf jedem Computer mit Windows 10/11 ausgeführt werden, ohne dass zuvor irgendwelche Bibliotheken installiert werden müssen.