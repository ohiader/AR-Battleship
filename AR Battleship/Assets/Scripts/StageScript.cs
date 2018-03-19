using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour {

	public static bool flipped = false; // false means the player board is showing, true means the enemy board is showing

	public GameObject stage, gameManagerPrefab, enemyManagerPrefab;

	public static bool begin = false;

	bool playerTurn = true; // player starts first
	bool enemyTurn = false;

	float rotZ;

	// Use this for initialization
	void Start () {
		rotZ = stage.gameObject.transform.localEulerAngles.z;

		if (ToggleSettings.scaleToggle) {
			stage.transform.localScale = new Vector3 (1.1f * 3.0f, 0.2f, 1.1f * 3.0f);
		}

		if (ToggleSettings.UiToggle) {
			//  shift all gameObjects over (make sure you have added a virtual button)
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (begin) {
			if (playerTurn) {
				if (gameManager.boardY > -6.0f) {
					gameManager.boardY -= 0.05f;
				} else {
					gameManagerPrefab.SetActive (false);
					rotZ += 2.0f;
					stage.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, rotZ);
					if (rotZ >= 180.0f) {
						stage.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 180.0f);
						rotZ = 180.0f;
						enemyManagerPrefab.SetActive (true);
						enemyManager.boardY = -4.0f;
						if (enemyManager.boardY < -2.5f) {
							enemyManager.boardY += 0.2f;
						} else {
							enemyManager.boardY = 2.5f;
							begin = false;
							flipped = true;
						}
					}
				}
			} else if (enemyTurn) {
				if (enemyManager.boardY > -4.0f) {
					enemyManager.boardY -= 0.2f;
				} else {
					enemyManagerPrefab.SetActive (false);
					rotZ -= 2.0f;
					stage.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, rotZ);
					if (rotZ <= 0.0f) {
						stage.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0.0f);
						rotZ = 0.0f;
						gameManagerPrefab.SetActive (true);
						gameManager.boardY = -6.0f;
						if (gameManager.boardY < -4.5f) {
							gameManager.boardY += 0.2f;
						} else {
							gameManager.boardY = -4.5f;
							begin = false;
							flipped = false;
						}
					}
				}
			}

		}
	}

	// Button Functions

	public void toPlayerBoard() {
		playerTurn = false;
		enemyTurn = true;
	}

	public void toEnemyBoard() {
		playerTurn = true;
		enemyTurn = false;
	}
}
