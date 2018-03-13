using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour {
	public MovieTexture spaceBg;

	// Use this for initialization
	void Start () {
		spaceBg.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!spaceBg.isPlaying) {
			spaceBg.Play ();
		}
	}
}
