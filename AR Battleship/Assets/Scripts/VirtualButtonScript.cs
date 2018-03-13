using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject vShip1Btn, vShip2Btn, vShip3Btn, vShip4Btn, vShip5Btn;
	public GameObject ship1, ship2, ship3, ship4, ship5;
	public GameObject redButton;

	// Use this for initialization
	void Start () {
		vShip1Btn = GameObject.Find ("Ship1Btn");
		vShip1Btn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		vShip2Btn = GameObject.Find ("Ship2Btn");
		vShip2Btn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		vShip3Btn = GameObject.Find ("Ship3Btn");
		vShip3Btn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		vShip4Btn = GameObject.Find ("Ship4Btn");
		vShip4Btn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		vShip5Btn = GameObject.Find ("Ship5Btn");
		vShip5Btn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "Ship1Btn") {
			ship1.transform.gameObject.SetActive (true);
		} else if (vb.gameObject.name == "Ship2Btn") {
			ship2.transform.gameObject.SetActive (true);
		} else if (vb.gameObject.name == "Ship3Btn") {
			redButton.transform.localScale = new Vector3(0.6f, 1f, 0.6f);
			ship3.transform.gameObject.SetActive (true);
		} else if (vb.gameObject.name == "Ship4Btn") {
			ship4.transform.gameObject.SetActive (true);
		} else if (vb.gameObject.name == "Ship5Btn") {
			ship5.transform.gameObject.SetActive (true);
		}

		Debug.Log ("Pressed");
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "Ship1Btn") {
			ship1.transform.gameObject.SetActive (false);
		} else if (vb.gameObject.name == "Ship2Btn") {
			ship2.transform.gameObject.SetActive (false);
		} else if (vb.gameObject.name == "Ship3Btn") {
			redButton.transform.localScale = new Vector3(0.6f, 2f, 0.6f);
			ship3.transform.gameObject.SetActive (false);
		} else if (vb.gameObject.name == "Ship4Btn") {
			ship4.transform.gameObject.SetActive (false);
		} else if (vb.gameObject.name == "Ship5Btn") {
			ship5.transform.gameObject.SetActive (false);
		}
		Debug.Log ("Released");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
