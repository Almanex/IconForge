[README_RU](README_RU.md) | [README_DE](README_DE.md) | [README_EN](../README.md) | [GUIDE_RU](GUIDE_RU.md) | [GUIDE_DE](GUIDE_DE.md) | [GUIDE_EN](GUIDE.md)

# SnapIcon

*Нативный мультиформатный генератор иконок и утилита обработки изображений для Windows 11*

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows%2010%20%2F%2011-blue)](https://www.microsoft.com/windows)
[![Framework: .NET 10.0](https://img.shields.io/badge/Framework-.NET%2010.0-blue)](https://dotnet.microsoft.com/download)
[![UI: WinUI 3](https://img.shields.io/badge/UI-WinUI%203-blue)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Release: v1.0.4](https://img.shields.io/badge/Release-v1.0.4-brightgreen)](https://github.com/Almanex/SnapIcon/releases/tag/v1.0.4)

SnapIcon — это легкое нативное приложение для Windows 11, разработанное на языке C# и фреймворке WinUI 3 (Windows App SDK) для целевой платформы .NET 10.0. Приложение поддерживает 3 языка интерфейса (русский, английский, немецкий) и предназначено для автоматической генерации пакетов иконок для Windows (`.ico`, `Assets`), Web (`Favicon Pack`), macOS (`.icns`) и Android (`Adaptive Icons`) из единичных или пакетных исходных файлов PNG, SVG или ICO.

Подробное пошаговое руководство см. в [Руководстве пользователя](GUIDE_RU.md).

---

## Основные возможности

### Кроссплатформенная генерация иконок

* **Windows (Классический .ico):**
  * Мультиформатный контейнер `.ico` с разрешениями: `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128`, `256x256` пикселей.
  * **Микро-шарпинг:** Автоматическое применение фильтра контурной резкости для мелких размеров (16-48px), исключающее размытие в Проводнике Windows.
* **Windows Modern Assets (PNG):**
  * Экспорт логотипов для манифеста UWP/WinUI приложений (`Square44x44Logo`, `Square150x150Logo`, `StoreLogo`) во всех системных масштабах: `scale-100`, `scale-125`, `scale-150`, `scale-200`, `scale-400`.
* **Web & Favicon Pack:**
  * Полный веб-пакет иконок: `favicon.ico`, `favicon-16x16.png`, `favicon-32x32.png`, `apple-touch-icon.png` (180x180), `android-chrome-192x192.png`, `android-chrome-512x512.png` и файл манифеста `site.webmanifest`.
* **macOS App Icon (.icns):**
  * Бинарный энкодер иконки Apple `.icns` с блоками разрешений `ic04`, `ic05`, `ic06`, `ic07`, `ic08`, `ic09`, `ic10`.
* **Android (Adaptive и Legacy Icons):**
  * Разделение слоев: безопасное позиционирование логотипа внутри зоны (72dp) слоя `Foreground.png` и заливка слоя `Background.png` выбранным цветом или изображением.
  * Структурированное дерево папок `mipmap-mdpi` — `mipmap-xxxhdpi`.
  * Круглая Legacy-иконка (`ic_launcher.png`) и промо-иконка Google Play `512x512`.

### Фильтры, Маски форм и Автообрезка

* **Автообрезка прозрачных полей (Auto-Crop):** Высокпроизводительный алгоритм определения границ объекта, удаляющий пустую прозрачную рамку перед наложением масок.
* **Векторные маски форм:** Формы **Скверкл (Squircle)** (гладкий iOS/Android контур), **Круг** (100% векторная окружность), **Капля (Teardrop)** и **Скругленный прямоугольник**.
* **Регулировки яркости и контраста:** Плавные ползунки Яркости (-100..+100) и Контраста (-100..+100).
* **Скругление и отступы:** Настройка радиуса скругления углов (0..50%) с гарантированной защитой пропорций $1:1$ от овализации, и внутренних отступов (0..40%).
* **Эффекты:** Черно-белый режим (Grayscale), Инверсия цветов и Тень (Drop Shadow).
* **SVG Tinting (Тинтинг):** Произвольная перекраска векторных и растровых иконок по Hex-коду.

### Сетка предпросмотра и Масштаб 1x/2x

* Одновременный вывод предпросмотра в стандартах `16x16`, `32x32`, `48x48`, `256x256`.
* **Переключатель масштаба 1x / 2x:** Режим чистого физического отображения 1:1 и 2x пиксельный лупа-просмотр.
* **Переключение фона:** Прозрачный (шахматка), Темный (#1F1F1F), Светлый (#F3F3F3) и Цвет фонового слоя Android.

### Пакетный режим и Извлечение кадров из ICO

* **Пакетная обработка (Batch Processing):** Выбор или Drag-and-Drop нескольких PNG/SVG файлов одновременно.
* **Reverse ICO Extraction:** Автоматическое извлечение встроенных слоев `.ico` в отдельные PNG-файлы.

### Интеграция с Windows 11 и единый EXE

* **Mica Alt & Dark/Light темы:** Адаптивный Fluent Design материал.
* **Контекстное меню Проводника:** Пункт "Сгенерировать иконки в SnapIcon" в классическом и современном меню Windows 11.
* **Одиночный файл EXE:** Полностью автономный файл (`SnapIcon.exe`). Таблица ресурсов `resources.pri` встроена внутрь `.exe`.

---

## Стек технологий

| Компонент | Технология | Описание |
| --- | --- | --- |
| Язык / Фреймворк | C# (.NET 10.0) | Target `net10.0-windows10.0.26100.0` |
| UI-платформа | WinUI 3 | Windows App SDK 1.6 / 2.2 |
| Графический движок | SkiaSharp | Сэмплинг (Lanczos3), цветовые матрицы |
| Векторная графика | Svg.Skia | Высокоточное растеризование SVG |
| Сборка | Single-File Executable | Автономный исполняемый `.exe` |

---

## Структура экспорта

```text
[Папка_Назначения]/
├── Windows/
│   ├── app_icon.ico
│   └── Assets/
│       ├── Square44x44Logo.scale-100.png
│       └── ...
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

## Сборка и запуск

```powershell
git clone https://github.com/Almanex/icoboo.git
cd icoboo
dotnet build
dotnet run
```

### Автономная публикация в 1 файл

```powershell
dotnet publish -c Release -r win-x64 --self-contained true
```

---

## Лицензия

Проект распространяется по лицензии [MIT](LICENSE).
