# UnityAutoIncrementBuildVersion
This is a simple automation tool for generating Unity build versions automatically. It also enables git-enabled Unity Cloud Build projects to AUTOMATICALLY increment the build number if you build with cloud build, so that you do not have to constantly push with new versions when building with cloud build.

1) It reads the current player setting's version information

2) It increases your build number and build version code by 1

3) If the build is on unity cloud build, it then saves your project settings and commits them back into git like this automatically. If it wasn't in cloud build, it just increases your version number and allows you to save project settings at your own convenience (make sure to do this before you push if you make your own builds)

![alt text](http://i.imgur.com/05rhU1w.png "Commit back")

4) The next time the build will be increased by 1, and you didn't have to do anything. This is useful when you want to automate your Unity build process and need to ship a lot of different versions quickly through cloud build.

# Before you start

1) Ensure that your bundle version is set to a proper semantic version (e.g 1.0.0) and not a 1.0 or 1. Also ensure your build version id is atually a correct number.

2) Ensure that your unity cloud build authorization has access to write to git as well as read from it.

3) If you use cloud build, set your build's custom defines properly so it can commit back to git: http://i.imgur.com/L7Kemih.png


# Installing
It's simple: 

Place the AutoIncrementBuildVersion.cs script in PROJECT ROOT/Editor/AutoIncrementBuildVersion.cs, and save the commit.sh file under your PROJECT ROOT/commit.sh.

In the same directory as commit.sh is located in, ```run ssh-keygen -t``` rsa to generate a deploy key. Simply call it "deploy". the commit.sh file will automatically add the deploy key to the local ssh session, as long as you properly name the key "deploy".

Like this:
```ssh
a:test wwadewitte$ ssh-keygen -t rsa
Generating public/private rsa key pair.
Enter file in which to save the key (/Users/wwadewitte/.ssh/id_rsa): deploy
Enter passphrase (empty for no passphrase): 
Enter same passphrase again: 
Your identification has been saved in deploy.
Your public key has been saved in deploy.pub.
The key fingerprint is:
```

Enter that deploy key as a deploy key in your github account under settings -> deploy keys

Commit deploy and deploy.pub to the repository so that unity cloud build can pull the keys down and use them

That's it! It will now hook into your build process, automatically update git, and any future versions. It will even commit files back to git for you and make sure your team always builds the next version. 

#Getting the version number inside your unity project
Simply call 

```C#
Application.version
```

Note: only works for Android and iOS at the moment. Feel free to add other platforms and make a pull request.
