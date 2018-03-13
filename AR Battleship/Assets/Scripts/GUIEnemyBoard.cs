using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIEnemyBoard : MonoBehaviour {

	public GameObject scope, aimForShipsPanel, shootBtn, updatePanel, missPanel;
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
		// if it is a miss
		if (enemyManager.reportBack == 0) {
			updatePanel.SetActive (false);
			shootBtn.SetActive (false);
			missPanel.SetActive (true);
		} else if (enemyManager.reportBack == 1) {
			updateText.color = Color.green;
			updateText.text = "Hit! Shoot again.";
		}
	}

	void Awake () {
		aimForShipsPanel.SetActive (true);
		shootBtn.SetActive (false);
	}

	public void closeAimPanel() {
		Destroy (aimForShipsPanel);
		if (!ToggleSettings.UiToggle) {
			shootBtn.SetActive (true);
		}
		updatePanel.SetActive (true);
	}

	public void closeMissPanel() {
		Color color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
		Initiate.Fade("playerBoard", color, 2.0f);
	}

}
