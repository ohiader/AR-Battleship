using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIEnemyBoard : MonoBehaviour {

	public GameObject scope, aimForShipsPanel, shootBtn, updatePanel, toPlayerBoardBtn, enemyBoardPrefab, arCamera;
	public Text updateText;
	bool switchOff = false;
	public static bool second = false;

	// Use this for initialization
	void Awake () {
		if (ToggleSettings.selectionToggle && StageScript.flipped) {
			scope.SetActive (true);
			arCamera.gameObject.GetComponent<IndirectSelection> ().enabled = true;
		} else if (!ToggleSettings.selectionToggle) {
			scope.SetActive (false);
			arCamera.gameObject.GetComponent<IndirectSelection> ().enabled = false;
		}
		if (ToggleSettings.UiToggle) {
			shootBtn.SetActive (false);
		}
		updateText.text = "Select a tile to target";
		enemyManager.reportBack = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyBoardPrefab.activeSelf && !switchOff) {
			updatePanel.SetActive (false);
			aimForShipsPanel.SetActive (true);
		}
			
			// if it is a miss
		if (enemyManager.reportBack == 0) {
			shootBtn.SetActive (false);
			toPlayerBoardBtn.SetActive (true);
			updateText.color = Color.white;
			updateText.text = "Missed!";
		} else if (enemyManager.reportBack == 1) {
			updateText.color = Color.green;
			updateText.text = "Hit! Shoot again.";
			second = false;
		}
	}

	public void closeAimPanel() {
		switchOff = true;
		aimForShipsPanel.SetActive (false);
		updatePanel.SetActive (true);
		updateText.text = "Select a tile to target";
		enemyManager.reportBack = 2;
		if (ToggleSettings.selectionToggle) {
			scope.SetActive (true);
			arCamera.gameObject.GetComponent<IndirectSelection> ().enabled = true;
		} else if (!ToggleSettings.selectionToggle) {
			scope.SetActive (false);
			arCamera.gameObject.GetComponent<IndirectSelection> ().enabled = false;
		}
		if (!ToggleSettings.UiToggle) {
			shootBtn.SetActive (true);
		}
	}

	public void toPlayerBoard() {
		updateText.text = "Moving to player board";
		StageScript.begin = true;
		this.gameObject.GetComponent<EnemyBehaviour> ().enabled = true;
		this.gameObject.GetComponent<GUIEnemyBoard> ().enabled = false;
		if (ToggleSettings.selectionToggle) {
			scope.SetActive (false);
			arCamera.gameObject.GetComponent<IndirectSelection> ().enabled = false;
		}
		EnemyBehaviour.find = true;
		toPlayerBoardBtn.SetActive (false);
	}

}
