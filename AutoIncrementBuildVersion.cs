using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEditor;
using System;
using System.Diagnostics;

public class AutoIncrementBuildVersion : MonoBehaviour
{

	/**
	 * 
	 * Simple version-incrementing service for Unity Cloud Build that is designed to run on git and Unity Cloud Build.
	 * 
	 * 
	 * Requirements:
	 * 1) Place the commit.sh file in your Unity project root directory 
	 * 2) Place this file at Editor/AutoIncrementBuildVersion.cs
	 * 3) It expects that you are using git for version control already, and simply commits back to the branch it is already using
	 * 
	 * For help: github.com/pimdewitte
	 * 
	 * */


	// Automatically increment the version number for each unity build. Particularly useful so you can push Unity Cloud Build projects to prod with a peace of mind.
	[PostProcessBuildAttribute (0)]
	public static void OnPostprocessBuild (BuildTarget buildTarget, string path)
	{

		//NOTE: Script expects X.X.X to be your bundleVersion ALREADY. In order for this to work, set your current version number and build number for Android and iOS to your next version (e.g. 1.2.204)

		string currentVersion = PlayerSettings.bundleVersion;

		try {
			int major = Convert.ToInt32 (currentVersion.Split ('.') [0]);
			int minor = Convert.ToInt32 (currentVersion.Split ('.') [1]);
			int build = Convert.ToInt32 (currentVersion.Split ('.') [2]) + 1;


			PlayerSettings.bundleVersion = major + "." + minor + "." + build;

			if (buildTarget == BuildTarget.iOS) {
				PlayerSettings.iOS.buildNumber = "" + build + "";
				UnityEngine.Debug.Log ("Finished with bundleversioncode:" + PlayerSettings.iOS.buildNumber + "and version" + PlayerSettings.bundleVersion);

			} else if (buildTarget == BuildTarget.Android) {
				PlayerSettings.Android.bundleVersionCode = build;
				UnityEngine.Debug.Log ("Finished with bundleversioncode:" + PlayerSettings.Android.bundleVersionCode + "and version" + PlayerSettings.bundleVersion);
			}		
			// It's important that you do not chane your project settings during a build in the cloud.


			// commit the settings to git only if you are in cloud build. If you save locally, we save your project settings so that you can commit them.
			#if CLOUD_BUILD
			AssetDatabase.SaveAssets(); // should only be project version
			commitFileToGit ("ProjectSettings/ProjectSettings.asset");
			#endif

		} catch (Exception e) {
			UnityEngine.Debug.LogError (e);
			UnityEngine.Debug.LogError ("AutoIncrementBuildVersion script failed. Make sure your current bundle version is in the format X.X.X (e.g. 1.0.0) and not X.X (1.0) or X (1).");
		}
	}

	public static void commitFileToGit (string name)
	{
		Process p = new Process ();
		p.StartInfo.FileName = "bash";
		p.StartInfo.Arguments = "commit.sh " + name + "";    
		// Pipe the output to itself - we will catch this later
		p.StartInfo.RedirectStandardError = true;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.CreateNoWindow = true;

		// Where the script lives
		p.StartInfo.UseShellExecute = false;

		p.Start ();
		UnityEngine.Debug.Log ("Comitting " + name + "to git");
		// Read the output - this will show is a single entry in the console - you could get  fancy and make it log for each line - but thats not why we're here
		UnityEngine.Debug.Log (p.StandardOutput.ReadToEnd ());
		p.WaitForExit ();
		p.Close ();
	}
}



