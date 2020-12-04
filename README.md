# ESSAdapterToXinput
This project allows you to use your GameCube controller plugged into your wii as a Generix XBox360Controller in your PC (assuming you have an ESSAdapter).

## History
As a Ocarina of Time speedrunner ([speedrun.com profile](https://www.speedrun.com/user/parazite)) I use waht we called an ESS Adapter to be able to vizualize our GameCube controller's input in a software like [NintendoSpy](https://github.com/jaburns/NintendoSpy).
This project cames up when I realized that I have a GameCube controller indirectly plugged in my PC but I can't use it in any other emulators. So I've developped this little tools that convert the input signal from a GameCube controller COM port (from my ESS Adapter) to a generic XBox360 Controller so that I can use my GameCube controller in software like : Bizhawk (for randomizer lovers <3), Dolphin, or more generally Steam.

## Prerequisities
As this tools relies on the fantastic [ViGEm](https://github.com/ViGEm/ViGEmBus) project, it's needed to install it's last release from [here](https://github.com/ViGEm/ViGEmBus/releases).

## Usage
1. Download the latest release of this project from [here](https://github.com/parazite13/ESSAdapterToXinput/releases) and start the ESSAdapterToXinput.exe application.
2. In the opened window you can pick your controller in the first ComboBox and then you can pick the associated COM port from the second ComboBox (exactly like NintendoSpy !)
3. Press the *Plug* button and your're good to go !

## Nota
This project is heavily inspired from [NintendoSpy](https://github.com/jaburns/NintendoSpy) to retrieve the controller input value from the COM port, so thanks a lot to *jaburns* and all the contributors to let me achieve this part with their source code.