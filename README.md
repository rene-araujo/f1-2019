# f1-2019
f1-2019 is a tool that generates the following results from a race log file:
* Gran prix result.
* Fastest laps per driver.
* Avarage speed per driver.
* Gap between winner and the other drivers.

## Usage

Run from command line inside project folder:

```
dotnet run --project ./src/f1-2019/f1-2019.csproj "RACE_LOG_FILE_PATH"
```

## Test

Tests were built with [NUnit](https://nunit.org/). Run them from command line inside project folder:

```
dotnet test ./src/f1-2019/f1-2019.csproj
```

## Built With

* [.NET Core 2.1](https://dotnet.microsoft.com/download) - .NET Core is a cross-platform version of .NET.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/rene-araujo/f1-2019/blob/master/LICENSE.md) file for details
