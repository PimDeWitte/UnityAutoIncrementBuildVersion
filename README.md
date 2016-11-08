# Unity-auto-version-increment
Simple post build script to increment each build version in Unity

#How-to
In Player Settings, make sure your version number is MAJOR.MINOR.BUILDNUMBER (e.g. 1.0.12) before running the script. X.X (1.0) or X (1) won't work. Also turn your build number setting into the same as the build number setting in the semantic version (Major.minor.buildnumber)

#Getting the version number inside your unity project
Simply call 
```C#
Application.version
```

Note: only works for Android and iOS at the moment. Feel free to add other platforms and make a pull request.
