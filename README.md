# UnityAutoIncrementBuildVersion
This is a simple automation tool for generating Unity build versions automatically on git-based Unity projects. 

1) It reads the current player setting's version information

2) It increases your build number and build version code by 1

3) It then saves your project settings and commits them back into git

# Before you start
In Player Settings, make sure your version number is MAJOR.MINOR.BUILDNUMBER (e.g. 1.0.12) before running the script. X.X (1.0) or X (1) won't work. Also turn your build number setting into the same as the build number setting in the semantic version (Major.minor.buildnumber)

# Installing
It's simple: Place the AutoIncrementBuildVersion.cs script in PROJECT ROOT/Editor/AutoIncrementBuildVersion.cs, and save the commit.sh file under your PROJECT ROOT/commit.sh

#Getting the version number inside your unity project
Simply call 
```C#
Application.version
```

Note: only works for Android and iOS at the moment. Feel free to add other platforms and make a pull request.
