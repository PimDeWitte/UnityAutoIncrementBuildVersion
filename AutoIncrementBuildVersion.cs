using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.iOS.Xcode;
using System.IO;
using System;

public class AutoIncrementBuildVersion : MonoBehaviour
{

  // Automatically increment the version number for each unity build. Particularly useful so you can push Unity Cloud Build projects to prod with a peace of mind.
  [PostProcessBuildAttribute(1)]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
  
  		string baseVersion = PlayerSettings.bundleVersion; // make sure this is X.X.X (e.g. 1.0.0) before running the script. X.X (1.0) or X (1) won't work.
		string fileName = "incr_version.txt";
		if(!File.Exists(fileName)) {
			File.WriteAllText (fileName, baseVersion);
		}
		
		//NOTE: Script expects X.X.X to be your bundleVersion ALREADY. In order for this to work, set your current version number and build number for Android and iOS to your next version (e.g. 1.2.204)
		
		string currentVersion = File.ReadAllText (fileName);

		int major = Convert.ToInt32(currentVersion.Split('.')[0]);
		int minor = Convert.ToInt32(currentVersion.Split('.')[1]);
		int build = Convert.ToInt32(currentVersion.Split('.')[2])+1;

		PlayerSettings.bundleVersion = major+"."+minor+"."+build;

		if (buildTarget == BuildTarget.iOS) {
			PlayerSettings.iOS.buildNumber = ""+build+"";
			Debug.Log ("Finished with bundleversioncode:" + PlayerSettings.iOS.buildNumber + "and version" + PlayerSettings.bundleVersion);

		} else if(buildTarget == BuildTarget.Android){
			PlayerSettings.Android.bundleVersionCode = build;
			Debug.Log ("Finished with bundleversioncode:" + PlayerSettings.Android.bundleVersionCode + "and version" + PlayerSettings.bundleVersion);
		}

		File.WriteAllText (fileName, PlayerSettings.bundleVersion);
		}

	}




}

