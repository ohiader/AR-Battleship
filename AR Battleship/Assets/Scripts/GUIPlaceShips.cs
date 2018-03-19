using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlaceShips : MonoBehaviour {

	public GameObject popupPanel, placeShipsPanel;
	public GameObject ship1Btn, ship2Btn, ship3Btn, ship4Btn, ship5Btn, doneBtn, updatePanel;
	public Text updateText;
	
	// Update is called once per frame
	void Update () {
		// checks which ship is being placed, then updates text for how many tiles need to be placed
		if (placeShipsPanel.activeSelf) {
			if (gameManager.shipIndex == 1) {
				if (gameManager.Ship1 > 0) {
					updateText.text = gameManager.Ship1 + "/2 Tiles Placed";
				} else {
					updateText.text = "0/2 Tiles Placed";
				}
			}
			if (gameManager.shipIndex == 2) {
				if (gameManager.Ship2 > 0) {
					updateText.text = gameManager.Ship2 + "/3 Tiles Placed";
				} else {
					updateText.text = "0/3 Tiles Placed";
				}
			}
			if (gameManager.shipIndex == 3) {
				if (gameManager.Ship3 > 0) {
					updateText.text = gameManager.Ship3 + "/3 Tiles Placed";
				} else {
					updateText.text = "0/3 Tiles Placed";
				}
			}
			if (gameManager.shipIndex == 4) {
				if (gameManager.Ship4 > 0) {
					updateText.text = gameManager.Ship4 + "/4 Tiles Placed";
				} else {
					updateText.text = "0/4 Tiles Placed";
				}
			}
			if (gameManager.shipIndex == 5) {
				if (gameManager.Ship5 > 0) {
					updateText.text = gameManager.Ship5 + "/5 Tiles Placed";
				} else {
					updateText.text = "0/5 Tiles Placed";
				}
			}
		}
	}

	public void okayPlaceShips() {
		// Close panel and show rest of GUI
		popupPanel.SetActive (false);
		placeShipsPanel.SetActive (true); 
		updatePanel.SetActive (true);
	}

	public void donePlacing() {
		placeShipsPanel.SetActive (false);
		updateText.text = "Moving to enemy board";
		this.gameObject.GetComponent<GUIEnemyBoard> ().enabled = true;
	}
}
