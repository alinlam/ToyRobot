# Toy Robot
Toy Robot Simulation
<p>The library can read in commands of the following form:

PLACE X, Y, DIRECTION<br/>
MOVE<br/>
LEFT<br/>
RIGHT<br/>
REPORT<br/>
EXAMPLE<br/>
EXIT<br/>
</p>

#The solution is using .NET 6 framework <br/>
Anyway, this library is simple, and designed in object oriented.<br/>
This project is purely in C# without external library.<br>
Once the project is cloned and the local environment has .net 6 framework ready, the code is ready to be combined and buildableM<br/>
Link to download .NET 6 framework  https://dotnet.microsoft.com/en-us/download

Things to do to build the solution in difference .net framework<br/>
> Create new Console Application in the .net framework you want<br/>
> Add these files to your project<br/>
>> ActionEnum.cs<br/>
>> DirectionEnum.cs<br/>
>> InputCommand.cs<br/>
>> Position.cs<br/>
>> Robot.cs<br/>
> For the Program.cs file, copy the internal class Program from this project to the default Program.cs in your project.<br/>
> Done<br/>

#To experience, and test the simulation, please download the executable file from here https://github.com/alinlam/ToyRobot/blob/master/ToyRobot/Published/ToyRobot.zip <br/>
#Once the console apps is run, there is some descriptions to introduce the application, and also 4 examples input to demonstrate how to move the Toy Robot.
#This project is extendable to nice layout and more complexity movement, and can add in unit tests to assert the results (for now, as time limit, I have used the sample inputs to verify the results).

#Thanks for reading, and hope you enjoy the application.
