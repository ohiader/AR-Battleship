using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIEnemyBoard : MonoBehaviour {

	public GameObject scope, aimForShipsPanel, shootBtn, updatePanel, toPlayerBoardBtn, enemyBoardPrefab;
	public Text updateText;


	// Use this for initialization
	void Start () {
		if (ToggleSettings.selectionToggle) {
			scope.SetActive (true);
		} else if (!ToggleSettings.selectionToggle) {
			scope.SetActive (false);
		}
		if (ToggleSettings.UiToggle) {
			shootBtn.SetActive (false);
		}
		updateText.text = "Select a tile to target";
		enemyManager.reportBack = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyBoardPrefab.activeSelf) {
			aimForShipsPanel.SetActive (true);
		}

		// if it is a miss
		if (enemyManager.reportBack == 0) {
			updatePanel.SetActive (false);
			shootBtn.SetActive (false);
			toPlayerBoardBtn.SetActive (true);
		} else if (enemyManager.reportBack == 1) {
			updateText.color = Color.green;
			updateText.text = "Hit! Shoot again.";
		}
	}

	public void closeAimPanel() {
		aimForShipsPanel.SetActive (false);
		if (!ToggleSettings.UiToggle) {
			shootBtn.SetActive (true);
		}
	}

	public void toPlayerBoard() {
		updateText.text = "Moving to player board";
	}

}
