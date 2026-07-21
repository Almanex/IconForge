# IconForge Benutzerhandbuch

Willkommen beim **IconForge**-Benutzerhandbuch! Dieses Dokument bietet eine detaillierte Anleitung zur Nutzung aller Funktionen von IconForge v1.0.2.

---

## Inhaltsverzeichnis
1. [Erste Schritte](#1-erste-schritte)
2. [Dateiauswahl & Laden](#2-dateiauswahl--laden)
3. [Bildfilter & Farbanpassung](#3-bildfilter--farbanpassung)
4. [Export-Ziele & Formate](#4-export-ziele--formate)
5. [Echtzeit-Vorschaugitter (Live Preview)](#5-echtzeit-vorschaugitter-live-preview)
6. [ICO-Extraktion (Reverse Extraction)](#6-ico-extraktion-reverse-extraction)
7. [System- & Explorer-Integration](#7-system--explorer-integration)
8. [Einzelne EXE-Datei (Single-File Deployment)](#8-einzelne-exe-datei-single-file-deployment)

---

## 1. Erste Schritte

IconForge wird als einzelne, eigenständige ausführbare Datei (`IconForge_v1.0.2_win-x64.exe`) geliefert. Es erfordert keine Installation oder Administratorrechte. Doppelklicken Sie einfach auf die `.exe`-Datei, um die Anwendung zu starten.

---

## 2. Dateiauswahl & Laden

Sie können Bilddateien über folgende Wege laden:
* **Drag-and-Drop:** Ziehen Sie eine Datei direkt in den Hauptbereich der Anwendung.
* **Durchsuchen:** Klicken Sie auf das Ordnersymbol, um eine Datei über den Windows-Dateiauswahldialog zu wählen.
* **Kontextmenü:** Klicken Sie im Windows Explorer mit der rechten Maustaste auf eine PNG-, SVG- oder ICO-Datei und wählen Sie **"Icons in IconForge generieren"**.

### Unterstützte Eingabeformate
* **PNG (`.png`):** Hochauflösende Rasterbilder (1024x1024 empfohlen).
* **SVG (`.svg`):** Skalierbare Vektorgrafiken (verlustfreie Schärfe bei allen Auflösungen).
* **ICO (`.ico`):** Mehrschichtige ICO-Dateien (aktiviert den ICO-Extraktionsmodus).

---

## 3. Bildfilter & Farbanpassung

Im linken Konfigurationsbereich stehen folgende Filter zur Verfügung:

* **Helligkeit (-100 bis +100):** Stufenlose Anpassung der Bildhelligkeit.
* **Kontrast (-100 bis +100):** Anpassung des Kontrastverhältnisses.
* **Eckenradius (%) (0 bis 50%):** Abrundung der Icon-Ecken.
* **Abstand (%) (0 bis 40%):** Innerer Abstand des Logos zum Icon-Rand.
* **Graustufenmodus:** Konvertiert Farben in Graustufen.
* **Farben invertieren:** Invertiert die RGB-Farbkanäle.
* **Schlagschatten (Drop Shadow):** Fügt einen weichen Schatten um die Logo-Silhouette hinzu.
* **Farbtönung (SVG Tint):** Eingabe eines Hex-Farbcodes (z. B. `#0078D4` oder `#3DDC84`) zum Einfärben von Vektor-Icons.

---

## 4. Export-Ziele & Formate

Wählen Sie die gewünschten Optionen im rechten Bedienfeld:

* **Windows Klassisch `.ico`:** Erstellt eine `app_icon.ico`-Datei mit den Auflösungen `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128` und `256x256` Pixel inklusive Mikro-Schärfung.
* **Windows Modern Assets:** Generiert einzelne PNG-Logos für WinUI/UWP-Manifeste in allen Systemskalierungen (`scale-100` bis `scale-400`).
* **Web & Favicon Pack:** Erstellt `favicon.ico`, `favicon-16x16.png`, `favicon-32x32.png`, `apple-touch-icon.png` (180x180), `android-chrome-*.png` und `site.webmanifest`.
* **macOS App Icon (`.icns`):** Erstellt ein binäres Apple `.icns`-Container-Paket.
* **Android Adaptive & Legacy Icons:** Erstellt Ebenen `Foreground.png` (Safe-Zone 72dp) und `Background.png`, Mipmap-Ordner (`mdpi` bis `xxxhdpi`), rundes `ic_launcher.png` und Google Play 512x512 Grafiken.

---

## 5. Echtzeit-Vorschaugitter (Live Preview)

Das Vorschaugitter auf der rechten Seite zeigt das Icon in Echtzeit in den Auflösungen `16x16`, `32x32`, `48x48` und `256x256` Pixel an.

### Hintergrundmodi
1. **Transparent:** Klassisches Schachbrettmuster.
2. **Dunkel:** `#1F1F1F` dunkler Hintergrund (Windows 11 Dark Taskbar).
3. **Hell:** `#F3F3F3` heller Hintergrund.
4. **Android/Projekt-Hintergrund:** Die in den Android-Einstellungen gewählte Hintergrundfarbe.

---

## 6. ICO-Extraktion (Reverse Extraction)

Beim Laden einer `.ico`-Datei werden alle enthaltenen PNG/BMP-Ebenen erkannt und können per Klick auf **"Alle Ebenen als PNG entpacken"** einzeln gespeichert werden.

---

## 7. System- & Explorer-Integration

* **Windows Explorer Kontextmenü:** Integration unter `HKEY_CURRENT_USER` ohne Administratorrechte.
* **Benachrichtigungen:** Toast-Benachrichtigung nach Fertigstellung mit Button zum Öffnen des Zielordners.

---

## 8. Einzelne EXE-Datei (Single-File Deployment)

IconForge v1.0.2 bettet alle MRT Core-Ressourcentabellen (`resources.pri`) direkt in die ausführbare Datei ein. Beim Start wird `resources.pri` automatisch extrahiert. Dadurch läuft `IconForge_v1.0.2_win-x64.exe` überall ohne Zusatzordner.
