### Tfl Coding Challenge

#Building the solution
The solution (TflCodingChallenge.sln) should be loaded into Visual Studio 2015 or Visual Studio 2017. All the projects target .net Framework version 4.6.1 which may need to be installed separately (https://www.microsoft.com/en-gb/download/details.aspx?id=49981)

The solution uses several nuget packages which will need to be restored before the solution will compile - depending upon the settings within Visual Studio, this may automatically happen when building, however it can be forced by right clicking on the solution within the Solution Explorer and selecting "Restore NuGet Packages".

The configuration file (App.Config) which is located in the console application (TflCodingChallenge\TflCodingChallenge\App.config) will need to be updated with the appropriate api id and app keys. These are settings within the appSettings section of the configuration file. The root url can also be changed in the configuration settings if required.

The solution should then be rebuilt using the menus - Build/Rebuild Solution.

#Running the solution
The solution can be run through Visual Studio by pressing F5 or Ctrl+F5 to run with/without debugging. In the project properties, under the Debug section, the command parameters can be supplied, for example A2.
The solution can also be run directly through a command window or Power Shell - once built, the exe file (RoadStatus.exe) will be placed in TflCodingChallenge\TflCodingChallenge\Bin\Debug and can be run from there via the command line or power shell.

#Return codes:
0: Success
1: Invalid input or Road not found
2: Api request failed
3: Exception thrown

#Example
`> RoadStatus.exe A2`
`The status of the A2 is as follows:`	
`    Road status is Closure`
`    Road status description is Closure`	

#Running the Unit and Integration tests
The unit and integration tests are built using the Microsoft testing framework. The easiest way to run them is to bring up the Test Explorer Window (in the Menus: Test/Windows/Test Explorer). The tests should appear in the Window and can be run either by clicking Run All or individually by Right Mouse Clicking on the test and clicking Run Selected Tests.

#Assumptions / Other information
The code assumes 
- that the request to https://api.tfl.gov.uk/road/<roadname> will return a JSON array containing only 1 item. This item is a JSON representation of the Tfl.Api.Presenstation.Entities.RoadCorridor type.
- that any HTTP response code other than 200 (OK) or 404 (Not Found) implies a failed request.