# Flight-investigation-application
> A Desktop application that interacts with a Flight Gear simulator app.
> This app desplays real time data changes of the flight Parameters, throught different charts and diagrams.
> The most important diagrams are the graphs, joystick, the video slider, playack speed and more..
## Whats required for getting started?
### Prerequisites
Download .NET 5.0, FlightGear Simulator.
for Developers: WPF, C#, c++ too. You can use Visual Studio 2019.
#### Dependencies
LiveChrts, LiveCharts.WPF
## Installing
Download the zip from this repository, or use git on the terminal:
```sh 
git clone https://github.com/Daviddor95/Flight-investigation-application
```
You need to open the .sln file in the zip, throught Visual Studio 2019 for example.
Than, open the FlightGear program on your computer.
Go to settings and after you entering:
```sh
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
Click "Fly".
After you here "Need help? use help tuturials"
Start our app (throught Visual studio for example).
## ✨ Special Features✨
- Player - The main slider you can use for going back and forth throught the flight time, and see the flightGear app changing constantly due to the time, speed, buttom we choose.
- Joystick - Responsible for showing the changes in the aileron (x-coordinate) and elevator(y-coordinate) 
features throught the flight, by the movement of the joystick 
and for showing the changes in the rudder and throttle features throught the flight, 
throught the movement of the little sliders near the joystick.
Also you can see the changes in the Data of Yaw, Pitch, Roll, Direction, Airspeed, Altimeter Desplayed too.
- charts - show a graph that empesizes the changes in a value of the flight feature we choose.
- another line that empesizes the same for the most correlated feature the first feature,
- another graph that emphesizes the line of regression and the exception values.
![alt text](https://github.com/Daviddor95/Flight-investigation-application/PicturesForREADME/Capture.jpg?raw=true)


## Project Structure
Our project is made out of 2 folders:
- Client - Everything connected to the interaction of our App with the FlightGear App.
- Settings - Includes playback_small.xml and the reg_flight.csv
- Controls - Contains 4 folders: Player, Joystick, Charts and main.

### Everyone of the controlls folders is responsible fora  different asspect:
Joystick is responsible fore the joystick and its sliders movement,
player for playing the flight video throught filght gear in certain speed and so on..

### Every controller is made in the MVVM design pattern:
It contains a model(A Partial Class) which holds the logic behind the movement/changes in the controller,
It contains a viewmodel which hold on the properties to connect to the view,
and a view which holds the way the controller looks like, 
in a xaml file which interacts with the view model throught Data Binding.
For every Controller, we created an inteface for the viewModel and for The model.
These interfaces extended the INotifyPropertyChanged Interface,
which enabled us to notify the properties of the model and the viewmodel, 
so evantually, the needed changes in the view will happen.
The main folder actually combines all the controllers together:
Creates a united view, and adds more functions to our Model (partial class)

## UML:

### More about implementation of Plugin
### For more info click here:

## Plugins

Dillinger is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |


