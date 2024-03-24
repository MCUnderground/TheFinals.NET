# TheFinals.NET

TheFinals.NET is a .NET wrapper for The Finals API. This library provides a simple and efficient way to interact with the API, allowing you to retrieve for eaxmple leaderboard data with ease.

## Features

- Supports multiple versions of the leaderboard API.
- Provides an interface to interact with the leaderboard service.
- Allows filtering of leaderboard entries by name.
- Supports retrieving a specific number of leaderboard entries.

## Installation

[![NuGet version (TheFinals.NET)](https://img.shields.io/nuget/v/TheFinals.NET?logo=nuget&logoColor=hsl(350%2C%2074%25%2C%2046%25)&labelColor=hsl(220%2C%206%25%2C%2090%25)&color=hsl(350%2C%2074%25%2C%2046%25))](https://www.nuget.org/packages/TheFinals.NET/)

## Usage

Here's a basic example of how to use TheFinals.NET:

```csharp
using TheFinals.NET.Endpoints;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;
using TheFinals.NET.Providers;

var client = new TheFinalsClient();
var leaderboardSeason2 = await client.Leaderboard.GetAsync(LeaderboardVersion.Season2);

var leaderboardSeason1Filters = await client.Leaderboard.GetAsync(LeaderboardVersion.Season1, Platform.Steam, count:500, nameFilter:"asd");
```

## Contributing

Contributions are always welcomed.

## Note

Project is not affiliated with [Embark Studios](https://www.embark-studios.com/) or [The Finals](https://www.reachthefinals.com/).

## Links
[Official The Finals Leaderboard](https://www.reachthefinals.com/leaderboard)

