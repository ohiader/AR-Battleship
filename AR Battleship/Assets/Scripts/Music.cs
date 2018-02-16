using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public static GameObject music;

	void Awake() {
		if (Music.music != null) {
			music.SetActive(true);
		} else {
			if (Music.music == null) {
				Debug.Log ("Made Music");
				music = (GameObject)Instantiate (Resources.Load ("Music"));
				music.SetActive (true);
			}
		}
		DontDestroyOnLoad (music);
	}
}
