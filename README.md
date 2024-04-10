# TheFinals.NET

TheFinals.NET is a .NET wrapper for The Finals API. This library provides a simple and efficient way to interact with the API, allowing you to retrieve for eaxmple leaderboard data with ease.

## Features

- Supports multiple versions/seasons of the leaderboard API.
- Simple api to get leaderboard data.
- Allows filtering of leaderboard entries by name.
- Supports retrieving a specific number of leaderboard entries.
- Supports retrieving League image for each league, as url or byte array.
- Supports retrieving some of the images, like embark logo, steam, psn and xbox.
- Supports event leaderboards, with PlatformPushEvent for now.

## Installation

[![NuGet version (TheFinals.NET)](https://img.shields.io/nuget/v/TheFinals.NET?logo=nuget&logoColor=hsl(350%2C%2074%25%2C%2046%25)&labelColor=hsl(220%2C%206%25%2C%2090%25)&color=hsl(350%2C%2074%25%2C%2046%25))](https://www.nuget.org/packages/TheFinals.NET/)

## Usage

Here's a basic example of how to use TheFinals.NET:

```csharp
using TheFinals.NET.Endpoints;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;
using TheFinals.NET.Providers;

TheFinalsClient client = new TheFinalsClient();
List<LeaderboardEntry> leaderboardSeason2 = await client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season2);
List<LeaderboardEntry> leaderboardSeason1Filters = await client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season1, Platform.Steam, count:500, nameFilter:"asd");

string imageUrl = client.League.GetImageUrl(leaderboardSeason2[0].League, LeagueImageType.Full);
byte[] imageByte = await client.League.GetImageAsync(League.Diamond4, LeagueImageType.Thumbnail); 

```

LeaderboardEntry includes League property, and can be used to get an League Image for example.

## Endpoints:

```csharp
TheFinalsClient
	Leaderboards
		Main
			List<LeaderboardEntry> GetAsync(LeaderboardVersion, Platform = Platform.Crossplay, int? = null, string = null)
		PlatformPushEvent
			PlatformPushEventLeaderboard GetAsync(int? = null, string = null)
TheFinalsClient
	League
		string GetImageUrl(League, LeagueImageType)
		byte[] GetImageAsync(League, LeagueImageType)
TheFinalsClient
	Image
		string GetUrl(League, LeagueImageType)
		byte[] GetAsync(League, LeagueImageType)
```

## Contributing

Contributions are always welcomed.

## Note

Project is not affiliated with [Embark Studios](https://www.embark-studios.com/) or [The Finals](https://www.reachthefinals.com/).

## Links
[Official The Finals Leaderboard](https://www.reachthefinals.com/leaderboard)

