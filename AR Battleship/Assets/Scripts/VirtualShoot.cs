using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualShoot : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject shootObj, vShootButton;

	// Use this for initialization
	void Start () {
		vShootButton = GameObject.Find ("VShootButton");
		vShootButton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "VShootButton") {
			// Decrease Y scale to make button look pressed
			shootObj.transform.localScale = new Vector3(0.7692308f, 0.5f, 0.7692308f);
		}

		Debug.Log ("Pressed");
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "VShootButton") {
			// Increase Y scale to make button look released
			shootObj.transform.localScale = new Vector3(0.7692308f, 1.2f, 0.7692308f);
			// shoot
			//shoot();
		}
		Debug.Log ("Released");
	}
}
