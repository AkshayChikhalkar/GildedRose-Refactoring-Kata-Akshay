# Gilded Rose starting position in C# xUnit

## Requirements
- .NET 8 SDK
The projects target `net8.0` instead of the original .NET 10 default, because .NET 8 is what’s installed on my machine.

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```