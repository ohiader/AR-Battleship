using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyARCamera : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Destroy(GameObject.Find ("ARCamera-MasterClone"));
	}

}
