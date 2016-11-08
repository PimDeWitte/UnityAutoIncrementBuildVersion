# Unity-auto-version-increment
Simple post build script to increment each build version in Unity

#How-to
Just place AutoIncrementBuildVersion.cs under your Editor/ directory and it should run automatically after every build. In Player Settings, make sure your version number is X.X.X (e.g. 1.0.0) before running the script. X.X (1.0) or X (1) won't work. 

#Getting the version number inside your unity project
Simply call 
```C#
Application.version
```

Note: only works for Android and iOS at the moment. Feel free to add other platforms and make a pull request.
