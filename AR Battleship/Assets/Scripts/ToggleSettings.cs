using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSettings : MonoBehaviour {

	public Toggle scale, ui, transition, selection;
	public GameObject panel;
	public static bool scaleToggle, selectionToggle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openSettings() {
		panel.SetActive (true);
	}

	public void closeSettings() {
		panel.SetActive (false);
	}

	public void toggleScale() {
		//switch between paper scale and table scale (3x)
		if (scale.isOn) {
			scaleToggle = true;
		} else {
			scaleToggle = false;
		}
	}

	public void toggleUI() {
		//switch between 2d fixed UI and 3D AR ui
	}

	public void toggleTransitions() {
		//fade to animation?
	}

	public void toggleSelection() {
		//switch between direct and indirect selection
		if (selection.isOn) {
			selectionToggle = true;
		} else {
			selectionToggle = false;
		}
	}

}
