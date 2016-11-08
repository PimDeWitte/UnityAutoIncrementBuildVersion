# UnityAutoIncrementBuildVersion
This is a simple automation tool for generating Unity build versions automatically on git-based Unity projects. 

1) It reads the current player setting's version information

2) It increases your build number and build version code by 1

3) It then saves your project settings and commits them back into git like this (This commit was automated):

![alt text](http://i.imgur.com/05rhU1w.png "Commit back")

4) The next time the build will be increased by 1, and you didn't have to do anything. This is useful when you want to automate your Unity build process and need to ship a lot of different versions quickly through cloud build.

# Before you start

1) Ensure that your bundle version is set to a proper semantic version (e.g 1.0.0) and not a 1.0 or 1. Also ensure your build version id is atually a correct number.

2) Ensure that your unity cloud build authorization has access to write to git as well as read from it.

# Installing
It's simple: Place the AutoIncrementBuildVersion.cs script in PROJECT ROOT/Editor/AutoIncrementBuildVersion.cs, and save the commit.sh file under your PROJECT ROOT/commit.sh - That's it! It will now hook into your build process, automatically update git, and any future versions.

#Getting the version number inside your unity project
Simply call 

```C#
Application.version
```

Note: only works for Android and iOS at the moment. Feel free to add other platforms and make a pull request.
