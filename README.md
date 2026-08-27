# ETS2 Developer & Console Mode Activator

A lightweight, zero-dependency Windows utility that automates enabling **Developer Mode** and the **Developer Console** in Euro Truck Simulator 2 (ETS2).

## Features

- **🚀 Automated Detection**: Auto-detects the default ETS2 configuration path (`Documents\Euro Truck Simulator 2\config.cfg`).
- **📂 Fallback Option**: Allows manual input of the configuration path if you use a custom save/configuration directory structure.
- **🛡️ Safe Backup**: Automatically creates a backup of your original configuration (`config.cfg.bak`) before making any edits.
- **⚙️ Instant Activation**: Automatically updates or appends `g_developer "1"` and `g_console "1"` config flags.
- **📦 Standalone Executable**: Compiled as a trimmed single-file C# utility requiring no pre-installed frameworks or runtimes.

---

## How to Download & Run

1. Download the latest compiled `ETS2_DevMode_Activator.exe` from the latest release:
   <p align="center">
     <a href="https://github.com/playhaux/ETS2-DevMode-Activator/releases/latest">
       <img src="https://img.shields.io/github/v/release/playhaux/ETS2-DevMode-Activator?label=Download%20Latest%20Release&style=for-the-badge&logo=github&color=2ea44f" alt="Download Latest Release" />
     </a>
   </p>
2. Double-click the executable to launch it.
3. The tool will scan for your configuration file. If found, it will apply the changes instantly.
4. If your config file is in a custom location, paste the path to your `config.cfg` file when prompted.

---

## How to Use Developer Mode In-Game

Once the activator has run successfully, start Euro Truck Simulator 2 and use the following features:

### 1. Developer Console
- Press the tilde key (**`~`** or **```** - usually located below the `ESC` key) to toggle the developer console overlay.
- You can type commands here such as `g_set_time <hour>` or `warp <speed>`.

### 2. Free Camera (Developer Camera)
- Press **`0`** on your main keyboard (above the letter keys, not on the Numpad) to switch to the free-roaming camera.
- **Controls**:
  - **Mouse**: Look around.
  - **Numpad 8 / 5**: Move Forward / Backward.
  - **Numpad 4 / 6**: Move Left / Right.
  - **Numpad 9 / 3**: Move Up / Down.
  - **Mouse Scroll Wheel**: Scroll up to speed up camera movement; scroll down to slow it down.

### 3. Teleportation
- While in Free Camera mode, position the camera close to the road or ground where you want to go.
- Press **`Ctrl + F9`** to teleport your truck and trailer directly to the camera's position.

### 4. Useful Console Commands
Here are some of the most common and useful console commands you can run:

| Command | Description | Example |
| :--- | :--- | :--- |
| `g_set_time [hh] [mm]` | Set the current in-game time | `g_set_time 12 00` (Sets time to noon) |
| `g_set_weather [id] [force]` | Change weather (`0` for sunny, `1` for rainy) | `g_set_weather 0` (Forces clear weather) |
| `warp [value]` | Change the game speed multiplier (Default is `1.0`) | `warp 0.8` (Slows game speed down) |
| `goto [city_name]` | Teleport free camera to a city | `goto paris` (Teleports camera to Paris) |
| `g_flyspeed [value]` | Adjust free camera speed | `g_flyspeed 50` |
| `g_traffic [0/1]` | Toggle AI traffic off (`0`) or on (`1`) | `g_traffic 0` (Clears all AI traffic) |
| `g_police [0/1]` | Toggle traffic fines off (`0`) or on (`1`) | `g_police 0` (Disables police fines) |
| `g_fatigue [0/1]` | Toggle driver fatigue simulation | `g_fatigue 0` (Prevents falling asleep) |
| `g_fps [0/1]` | Toggle built-in FPS counter display | `g_fps 1` (Shows frames per second) |

---

## Build from Source

If you prefer to compile the application yourself, make sure you have the [.NET 6.0 SDK](https://dotnet.microsoft.com/download) installed and run:

```bash
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained true -p:PublishTrimmed=true
```
The compiled output will be generated inside `bin/Release/net6.0/win-x64/publish/`.

---

## 📄 License

This project is licensed under the **GNU General Public License v3.0 (GPLv3)**. See the [LICENSE](LICENSE) file for details.

---

<p align="center">
  <a href="https://ko-fi.com/playhaux">
    <img src="https://img.shields.io/badge/Donate-Ko--fi-72a4f2?style=for-the-badge&logo=ko-fi&logoColor=white" alt="Donate on Ko-fi" />
  </a>
</p>

<p align="center">
  Designed with ❤️ by <a href="https://playhaux.com"><b>Playhaux</b></a>
</p>
