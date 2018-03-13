using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour {

	public Button ship1Btn, ship2Btn, ship3Btn, ship4Btn, ship5Btn;
	Color pressed = new Color(0.7f, 0.7f, 0.7f, 1f);
	Color disabled = new Color(0.7f, 0.7f, 0.7f, 0.5f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// disable ship placement buttons after the entire ship is placed
		if (gameManager.count1 == 1) {
			ship1Btn.image.color = disabled;
			ship1Btn.interactable = false;
		}
		if (gameManager.count2 == 1) {
			ship2Btn.image.color = disabled;
			ship2Btn.interactable = false;
		}
		if (gameManager.count3 == 1) {
			ship3Btn.image.color = disabled;
			ship3Btn.interactable = false;
		}
		if (gameManager.count4 == 1) {
			ship4Btn.image.color = disabled;
			ship4Btn.interactable = false;
		}
		if (gameManager.count5 == 1) {
			ship5Btn.image.color = disabled;
			ship5Btn.interactable = false;
		}

		// When pressed, buttons switch and stay to pressed state
		if ((gameManager.shipIndex == 1) && (gameManager.count1 != 1)) {
			ship1Btn.image.color = pressed;
			ship2Btn.image.color = Color.white;
			ship3Btn.image.color = Color.white;
			ship4Btn.image.color = Color.white;
			ship5Btn.image.color = Color.white;
		}
		if ((gameManager.shipIndex == 2) && (gameManager.count2 != 1)) {
			ship2Btn.image.color = pressed;
			ship1Btn.image.color = Color.white;
			ship3Btn.image.color = Color.white;
			ship4Btn.image.color = Color.white;
			ship5Btn.image.color = Color.white;
		}
		if ((gameManager.shipIndex == 3) && (gameManager.count3 != 1)) {
			ship3Btn.image.color = pressed;
			ship2Btn.image.color = Color.white;
			ship1Btn.image.color = Color.white;
			ship4Btn.image.color = Color.white;
			ship5Btn.image.color = Color.white;
		}
		if ((gameManager.shipIndex == 4) && (gameManager.count4 != 1)) {
			ship4Btn.image.color = pressed;
			ship2Btn.image.color = Color.white;
			ship3Btn.image.color = Color.white;
			ship1Btn.image.color = Color.white;
			ship5Btn.image.color = Color.white;
		}
		if ((gameManager.shipIndex == 5) && (gameManager.count5 != 1)) {
			ship5Btn.image.color = pressed;
			ship2Btn.image.color = Color.white;
			ship3Btn.image.color = Color.white;
			ship4Btn.image.color = Color.white;
			ship1Btn.image.color = Color.white;
		}

	}
}
