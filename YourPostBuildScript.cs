using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.iOS.Xcode;
using System.IO;
using System;

public class YourPostBuildScript : MonoBehaviour
{

  // Automatically increment the version number for each unity build. Particularly useful so you can push Unity Cloud Build projects to prod with a peace of mind.
  [PostProcessBuildAttribute(1)]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
  
		string fileName = "incr_version.txt";
		if(!File.Exists(fileName)) {
			File.WriteAllText (fileName, PlayerSettings.bundleVersion);
		}

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

