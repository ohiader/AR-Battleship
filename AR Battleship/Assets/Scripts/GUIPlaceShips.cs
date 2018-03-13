using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlaceShips : MonoBehaviour {

	public GameObject placeShipsPanel, okayBtn;
	public GameObject ship1Btn, ship2Btn, ship3Btn, ship4Btn, ship5Btn, doneBtn, tilesPlacedPanel;
	public Text tilesPlacedText;
	
	// Update is called once per frame
	void Update () {
		// checks which ship is being placed, then updates text for how many tiles need to be placed
		if (gameManager.shipIndex == 1) {
			if (gameManager.Ship1 > 0) {
				tilesPlacedText.text = gameManager.Ship1 + "/2 Tiles Placed";
			} else {
				tilesPlacedText.text = "0/2 Tiles Placed";
			}
		}
		if (gameManager.shipIndex == 2) {
			if (gameManager.Ship2 > 0) {
				tilesPlacedText.text = gameManager.Ship2 + "/3 Tiles Placed";
			} else {
				tilesPlacedText.text = "0/3 Tiles Placed";
			}
		}
		if (gameManager.shipIndex == 3) {
			if (gameManager.Ship3 > 0) {
				tilesPlacedText.text = gameManager.Ship3 + "/3 Tiles Placed";
			} else {
				tilesPlacedText.text = "0/3 Tiles Placed";
			}
		}
		if (gameManager.shipIndex == 4) {
			if (gameManager.Ship4 > 0) {
				tilesPlacedText.text = gameManager.Ship4 + "/4 Tiles Placed";
			} else {
				tilesPlacedText.text = "0/4 Tiles Placed";
			}
		}
		if (gameManager.shipIndex == 5) {
			if (gameManager.Ship5 > 0) {
				tilesPlacedText.text = gameManager.Ship5 + "/5 Tiles Placed";
			} else {
				tilesPlacedText.text = "0/5 Tiles Placed";
			}
		}
	}

	public void okayPlaceShips() {
		// Close panel and show rest of GUI
		placeShipsPanel.SetActive (false);
		ship1Btn.SetActive (true);
		ship2Btn.SetActive (true);
		ship3Btn.SetActive (true);
		ship4Btn.SetActive (true);
		ship5Btn.SetActive (true);
		doneBtn.SetActive (true);
		tilesPlacedPanel.SetActive (true);
	}
}
