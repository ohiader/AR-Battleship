using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public Material inactive = null;
	public Material active = null;
	public Material miss = null;
	public Material hit = null;

	public int i;
	public int j;
	public static bool horizontalSearch = true;
	public static bool changeWay = false;
	public static bool searching = false;
	bool find = false;
	public static int leftOrRight = 0;
	public static int upOrDown = 1;
	public static int origI;
	public static int origJ;


	// Use this for initialization
	void Start () {
		if (searching == false) {
			i = (int)Random.Range (0, 9);
			j = (int)Random.Range (0, 9);
		}
		else{
			//look for adjacent
			i = origI;
			j = origJ;

			if (horizontalSearch && changeWay) {
				horizontalSearch = false;
				changeWay = false;
			} else if (horizontalSearch && !changeWay) {
				changeWay = true;
				if (leftOrRight == 0)
					leftOrRight = 1;
				else
					leftOrRight = 0;
			} else if (!horizontalSearch && changeWay) {
				horizontalSearch = true;
			} else {
				changeWay = true;
				if (upOrDown == 0)
					upOrDown = 1;
				else
					upOrDown = 0;
			}

			if (horizontalSearch) {
				if (i == 9) {
					i--;
				} else if (i == 0) {
					i++;
				} else if (leftOrRight == 0) { // search to the right 
					i++;
				} else {
					i--;
				}
			} else {
				if (j == 9) {
					j--;
				} else if (j == 0) {
					j++;
				} else if (upOrDown == 0) { // search up 
					j++;
				} else {
					j--;
				}
			}
		}

		if (gameManager.playerShips > 0) {
			//Check if the spot has not already been hit
			Debug.Log ("Ships left");
			Debug.Log (i);
			Debug.Log (j);
			Debug.Log (gameManager.playerBoard [i, j].tag);
			if (gameManager.playerBoard[i, j].tag.CompareTo("Inactive") == 0) {
				//This will result in a miss
				//Move to enemyBoard scene
				Debug.Log ("AI miss");
				gameManager.playerBoard[i,j].GetComponent<Renderer> ().material = miss;

				//				}
			} else if (gameManager.playerBoard[i, j].tag.StartsWith ("Ship")) {
				// This will be a hit
				Debug.Log ("AI hit");
				gameManager.playerBoard[i,j].GetComponent<Ship>().takeDamage ();
				gameManager.playerBoard[i,j].GetComponent<Renderer>().material = hit;
				searching = true;
				origI = i;
				origJ = j;
				if (gameManager.playerBoard[i,j].GetComponent<Ship>().isSunk ()) {
					gameManager.playerShips--;
					//change i and j
					searching = false;
					i = (int) Random.Range (0, 9);
					j = (int) Random.Range (0, 9);
					leftOrRight = (int)Random.Range (0, 1);
					upOrDown = (int)Random.Range (0, 1);
				}
				find = true;
			}
		} else { // if no ships left
			//searching = false;
			Debug.Log ("AI win");
			Color color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
			Initiate.Fade("GameOver", color, 2.0f);
			//Application.LoadLevel ("GameOver");
		}
	}

	// Update is called once per frame
	void Update () {
		// Guess a target 

		while (find) {
			searching = true;
			//look for adjacent
			if (horizontalSearch) {
				if (i == 9) {
					i--;
				} else if (i == 0) {
					i++;
				} else if (leftOrRight == 0) { // search to the right 
					i++;
				} else {
					i--;
				}
			} else {
				if (j == 9) {
					j--;
				} else if (j == 0) {
					j++;
				} else if (upOrDown == 0) { // search up 
					j++;
				} else {
					j--;
				}
			}

			if (gameManager.playerShips != 0) {
				//Check if the spot has not already been hit
				if (gameManager.playerBoard [i, j].tag.CompareTo("Inactive") == 0) {
					//This will result in a miss
					//Move to enemyBoard scene
					Debug.Log ("AI miss");
					find = false;
					gameManager.playerBoard[i,j].GetComponent<Renderer> ().material = miss;
				} else if (gameManager.playerBoard [i, j].tag.StartsWith ("Ship")) {
					// This will be a hit
					Debug.Log ("AI hit");
					gameManager.playerBoard[i,j].GetComponent<Ship>().takeDamage ();
					gameManager.playerBoard[i,j].GetComponent<Renderer>().material = hit;
					searching = true;
					if (gameManager.playerBoard[i,j].GetComponent<Ship>().isSunk ()) {
						gameManager.playerShips--;
						//change i and j
						i = (int) Random.Range (0, 9);
						j = (int) Random.Range (0, 9);
						leftOrRight = (int)Random.Range (0, 1);
						upOrDown = (int)Random.Range (0, 1);
						searching = false;
					} 
				}
			} else {
				find = false;
				Debug.Log ("AI win");
				Color color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
				Initiate.Fade("GameOver", color, 2.0f);
				//Application.LoadLevel ("GameOver");
			}
		}

		//Application.LoadLevel ("enemyBoard");
	}

	public void moveOn() {
		Color color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
		Initiate.Fade("enemyBoard", color, 2.0f);
		//Application.LoadLevel ("enemyBoard");
	}

}
