# Tfl Coding Challenge

### Building the solution
The solution (TflCodingChallenge.sln) should be loaded into Visual Studio 2015 or Visual Studio 2017. All the projects target .net Framework version 4.6.1 which may need to be installed separately (https://www.microsoft.com/en-gb/download/details.aspx?id=49981)

The solution uses several nuget packages which will need to be restored before the solution will compile - depending upon the settings within Visual Studio, this may automatically happen when building, however it can be forced by right clicking on the open solution within the Solution Explorer and selecting "Restore NuGet Packages".

The configuration file (App.Config) which is located in the console application (TflCodingChallenge\App.config) will need to be updated with the appropriate app id and app keys. These are settings within the appSettings section of the configuration file. The root url can also be changed in the configuration settings if required.

The solution should then be rebuilt using the Visual Studio menus - Build/Rebuild Solution.

### Running the Unit and Integration tests

The unit and integration tests are built using the Microsoft testing framework. The easiest way to run them is to bring up the Test Explorer Window (in the Visual Studio Menus: Test/Windows/Test Explorer). The tests should appear in the Window (you may have to rebuild the project to force them to appear) and can be run either by clicking Run All at the top of the Test Explorer window or individually by Right Mouse Clicking on the test and clicking Run Selected Tests.

### Running the solution

The solution can be run through Visual Studio by pressing F5 or Ctrl+F5 to run with/without debugging. To supply a road name (or test other command parameters) enter the required text into the 'Command line arguments' field, under the Debug section of the TflCodingChallenge console application project properties.

The solution can also be run directly through a command window or Power Shell - once built, the exe file (RoadStatus.exe) will be placed in TflCodingChallenge\Bin\Debug and can be run from there using typed commands, eg `RoadStatus.exe A2`.

### Return codes:

0: Success

1: Road not found / Empty road parameter  

2: Api request failed

3: Exception thrown

### Example usage and output

    RoadStatus.exe A2
    The status of the A2 is as follows:
        Road status is Closure
        Road status description is Closure

### Assumptions and Other information

The code assumes 

- that the request to https://api.tfl.gov.uk/road/<roadname> will return a JSON array containing only 1 item. This item is a JSON representation of the Tfl.Api.Presenstation.Entities.RoadCorridor type.

- that any HTTP response code other than 200 (OK) or 404 (Not Found) implies a failed request.

In addition to the specified output the console application will return a short hint of it's usage if it is run with no parameters and return Not Found (code 1).

If an unexpected HTTP response code is received from the API, the console application will display an appropriate message and return Api request failed (code 2).

If an exception occurs during the execution, the exception is caught, and the exception is written to screen to allow further investigation of the issue. The console app returns Exception thrown (code 3).
