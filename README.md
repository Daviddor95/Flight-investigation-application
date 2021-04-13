# Flight-investigation-application
> A Desktop application that interacts with a Flight Gear simulator app.
> This app displays real time data changes of the flight Parameters, throught different charts and diagrams.
> The most important diagrams are the graphs, joystick, the video slider, playback speed and more..


<img src = "https://github.com/Daviddor95/Flight-investigation-application/blob/master/PicturesForREADME/middleScreen.png" width="600" height="450"></br>

## Whats required for getting started?
### Prerequisites
Download .NET 4.7.2, FlightGear Simulator.
for Developers: WPF, C#, c++ too. You can use Visual Studio 2019.
#### Dependencies
LiveChrts, LiveCharts.WPF
## Installing
Download the zip from this repository, or use git on the terminal:
```sh 
git clone https://github.com/Daviddor95/Flight-investigation-application
```
You need to open the .sln file in the zip, through  Visual Studio 2019 for example.
Than, open the FlightGear program on your computer.
Go to settings and after you entering:
```sh
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
Click "Fly".
After you hear "Need help? use help tutorials"
Start our app (through Visual studio for example).
## ✨ Special Features✨
- Player - The main slider you can use for going back and forth through the flight time, and see the flightGear app changing constantly due to the time, speed, buttom we choose.
- Joystick - Responsible for showing the changes in the aileron (x-coordinate) and elevator(y-coordinate) 
features through the flight, by the movement of the joystick 
and for showing the changes in the rudder and throttle features through the flight, 
through the movement of the little sliders near the joystick.
Also you can see the changes in the Data of Yaw, Pitch, Roll, Direction, Airspeed, Altimeter Displayed too.
- charts - show a graph that emphasizes the changes in a value of the flight feature we choose, compares to another feature.
- another graph that emphasizes the last 30 values of the feature we chose.

## Project Structure
Our project is made out of 3 folders:
- Client - Everything connected to the interaction of our App with the FlightGear App.
- Settings - Includes playback_small.xml and the reg_flight.csv
- Controls - Contains 4 folders: Player, Joystick, Charts and main.

### Everyone of the controlls folders is responsible fora  different aspect:
Joystick is responsible fore the joystick and its sliders movement,
player for playing the flight video through filght gear in certain speed and so on..

### Every controller is made in the MVVM design pattern:
It contains a model(A Partial Class) which holds the logic behind the movement/changes in the controller,
It contains a viewmodel which hold on the properties to connect to the view,
and a view which holds the way the controller looks like, 
in a xaml file which interacts with the view model through Data Binding.
For every Controller, we created an inteface for the viewModel and for The model.
These interfaces extended the INotifyPropertyChanged Interface,
which enabled us to notify the properties of the model and the viewmodel, 
so eventually, the needed changes in the view will happen.
Every View of every controller, extends the UserControl class, and they are all used in the main View.
The main folder actually combines all the controllers together:
Creates a united view, and adds more functions to our Model (partial class)
### for Demonstration  of the app click here:
https://youtu.be/Sf_riQ1MhFA
## UML:
<img src = "https://github.com/Daviddor95/Flight-investigation-application/blob/master/PicturesForREADME/Uml.png" width="650" height="350"></br>


