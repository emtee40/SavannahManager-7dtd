# SavannahManager
Savannah Manager is a management tool for 7 Days to Die server.
The goal is to make all management possible with software. 

I developed it thinking that it will be easier even a little.  
As a background to development, my server administrator of acquaintance seemed to be bothersome managing server on cmd, so I thought it would be easier a little as I developed it.  
Also, it was troublesome for me to open several screens and I wanted to realize it with one screen or one software.  
One reason is that there were few domestic tools.  

The name was from the acquaintance and he said  "Ease management ('Saboreru' on Japanese )".  
I thought it was exactly so I used it.  
Thank you very much.  

# Development environment
1. Visual Studio 2019
2. [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)

# Build
## Visual Studio 2019
### Steps
1. Open SavannahManager.sln.
3. Click Build on Menu.

## MSBuild (without Visual Studio 2019)
### Required Tools
1. [Build Tools for Visual Studio 2019](https://www.visualstudio.com/ja/downloads/)
2. [NuGet](https://www.nuget.org/downloads)

### Steps
1. Download [NuGet](https://www.nuget.org/downloads) to project folder.
\*Pass the path if you have already installed.

2. Open Developer Command Prompt for VS 2019.

3. Open the project folder at cmd.
```sh
cd /D D:\Develop\Git\SavannahManager
```

4. Restore nuget packages.
```sh
nuget restore SavannahManager.sln
```

5. Build with MSBuild.
```sh
msbuild SavannahManager.sln /t:Clean;Build /p:Configuration=Release;Platform=x86
```

# Special Thanks
ReactiveProperty:               Copyright (c) 2018 neuecc, xin9le, okazuki  
Prism.Core:                     Copyright (c) .NET Foundation  
Microsoft.Xaml.Behaviors.Wpf:   Copyright (c) 2015 Microsoft  
NUnit:                          Copyright (c) 2019 Charlie Poole, Rob Prouse  
Newtonsoft.Json:                Copyright (c) 2007 James Newton-King  
Moq:                            Copyright (c) 2007, Clarius Consulting, Manas Technology Solutions, InSTEDD


This software includes the work that is distributed in the Apache License 2.0
