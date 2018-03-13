using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeThisWillWork : MonoBehaviour {
	GameObject player1 = null;

	public static GameObject battleShip1;
	public static GameObject battleShip2;
	public static GameObject battleShip3;
	public static GameObject battleShip4;
	public static GameObject battleShip5;

	bool check4 = true;
	bool check5 = true;

	public Material inactive = null;
	public Material active = null;



	//public Text text;

	void OnMouseDown() {
		if ( Input.GetMouseButtonDown(0))
		{
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) 
				{
					player1 = gameManager.playerBoard[i, j];
					if (gameObject.name.Equals(player1.name)) {
						if (gameObject.GetComponent<Renderer>().material.name.Contains("grid")) {
							if (gameManager.shipIndex == 1 && gameManager.Ship1 <= 1) {
								if (gameManager.Ship1 != 2 && isAdjacent(i, j)) {
									player1.transform.tag = "Ship1";
									gameManager.Ship1++;
									//Debug.Log (gameManager.Ship1 + "");
									player1.GetComponent<Renderer> ().material = active;
									gameManager.ship1 = gameManager.playerBoard [i, j].AddComponent<Ship> () as Ship;
									if (gameManager.Ship1 == 1) {
										gameManager.shipTransform1 = gameObject.transform;
									}
								}
								if (gameManager.Ship1 == 2) {
									gameManager.count1 = 1;
									gameManager.b1.SetActive (true);
									Debug.Log (gameManager.b1.activeSelf);
									gameManager.b1.transform.position = gameManager.shipTransform1.position;
									if (gameManager.ship1Dir == 1) { //vertical
										gameManager.b1.transform.localEulerAngles = new Vector3(0,90,0); //.RotateAround (gameManager.b1.transform.position, Vector3.forward, 90);
									}
								}
							}
							else if (gameManager.shipIndex == 2 && gameManager.Ship2 <= 2 ) {
								if (gameManager.Ship2 != 3 && isAdjacent(i, j)) {
									player1.transform.tag = "Ship2";
									gameManager.Ship2++;
									//Debug.Log (gameManager.Ship2 + "");
									player1.GetComponent<Renderer> ().material = active;
									gameManager.ship2 = gameManager.playerBoard [i, j].AddComponent<Ship> () as Ship;
									if (gameManager.Ship2 == 2) {
										gameManager.shipTransform2 = gameObject.transform;
									}
								}
								if (gameManager.Ship2 == 3) {
									gameManager.count2 = 1;
									gameManager.b2.SetActive(true);
									gameManager.b2.transform.position = gameManager.shipTransform2.position;
									if (gameManager.ship2Dir == 1) { //vertical
										gameManager.b2.transform.localEulerAngles = new Vector3(0,90,0);									}
								}
							}
							else if (gameManager.shipIndex == 3 && gameManager.Ship3 <= 3 ) {
								if (gameManager.Ship3 != 3 && isAdjacent(i, j)) {
									player1.transform.tag = "Ship3";
									gameManager.Ship3++;
									//Debug.Log (gameManager.Ship3 + "");
									player1.GetComponent<Renderer> ().material = active;
									gameManager.ship3 = gameManager.playerBoard [i, j].AddComponent<Ship> () as Ship;
									if (gameManager.Ship3 == 1) {
										gameManager.shipTransform3 = gameObject.transform;
									}
								}
								if (gameManager.Ship3 == 3) {
									gameManager.count3 = 1;
									gameManager.b3.SetActive(true);
									gameManager.b3.transform.position = gameManager.shipTransform3.position;
									if (gameManager.ship3Dir == 1) { //vertical
										gameManager.b3.transform.localEulerAngles = new Vector3(0,90,0);									} 
								}
							}
							else if (gameManager.shipIndex == 4 && gameManager.Ship4 <= 4 ) {
								if (gameManager.Ship4 != 4 && isAdjacent(i, j)) {
									player1.transform.tag = "Ship4";
									gameManager.Ship4++;
									//Debug.Log (gameManager.Ship4 + "");
									player1.GetComponent<Renderer> ().material = active;
									gameManager.ship4 = gameManager.playerBoard[i, j].AddComponent<Ship> () as Ship;
									if (gameManager.Ship4 == 2) {
										gameManager.shipTransform4 = gameObject.transform;
									}
								}
								if (gameManager.Ship4 == 4) {
									gameManager.count4 = 1;
									gameManager.b4.SetActive(true);
									gameManager.b4.transform.position = gameManager.shipTransform4.position;
									if (gameManager.ship4Dir == 2 && check4) { //horizontal
										gameManager.b4.transform.localEulerAngles = new Vector3(0, -90, 0);
											check4 = false;
									}
								}
							}
							else if (gameManager.shipIndex == 5 && gameManager.Ship5 <= 5) {
								if (gameManager.Ship5 != 5 && isAdjacent(i, j)) {
									player1.transform.tag = "Ship5";
									gameManager.Ship5++;
									//Debug.Log (gameManager.Ship5 + "");
									player1.GetComponent<Renderer> ().material = active;
									gameManager.ship5 = gameManager.playerBoard [i, j].AddComponent<Ship> () as Ship;
									if (gameManager.Ship5 == 3) {
										gameManager.shipTransform5 = gameObject.transform;
									}
								}
								if (gameManager.Ship5 == 5) {
									gameManager.count5 = 1;
									gameManager.b5.SetActive(true);
									gameManager.b5.transform.position = gameManager.shipTransform5.position;
									if (gameManager.ship5Dir == 1 && check5) { //vertical
										gameManager.b5.transform.localEulerAngles = new Vector3(0,90,0);
										check5 = false;
									}
								}
							}
							else
							{
								player1.GetComponent<Renderer>().material = inactive;
								player1.tag = "Inactive";
							}
						}else {
							if (gameManager.shipIndex == 1 && gameManager.Ship1 >= 0) {
								if (gameManager.Ship1 != 0) {
									if (gameManager.Ship1 < 2) {
										gameManager.count1 = 0;
										gameManager.b1.SetActive(false);
									}
									gameManager.Ship1--;
									resetArray (i, j);
									//Debug.Log (gameManager.Ship1 + "");
									player1.GetComponent<Renderer> ().material = inactive;
									player1.tag = "Inactive";
								}
							}
							if (gameManager.shipIndex == 2 && gameManager.Ship2 >= 0) {
								if (gameManager.Ship2 != 0) {
									if (gameManager.Ship2 < 3) {
										gameManager.count2 = 0;
										gameManager.b2.SetActive(false);
									}
									gameManager.Ship2--;
									resetArray (i, j);
									//Debug.Log (gameManager.Ship2 + "");
									player1.GetComponent<Renderer> ().material = inactive;
									player1.tag = "Inactive";
								}
							}
							if (gameManager.shipIndex == 3 && gameManager.Ship3 >= 0) {
								if (gameManager.Ship3 != 0) {
									if (gameManager.Ship3 < 3) {
										gameManager.count3 = 0;
										gameManager.b3.SetActive(false);
									}
									gameManager.Ship3--;
									resetArray (i, j);
									//Debug.Log (gameManager.Ship3 + "");
									player1.GetComponent<Renderer> ().material = inactive;
									player1.tag = "Inactive";
								}
							}
							if (gameManager.shipIndex == 4 && gameManager.Ship4 >= 0) {
								if (gameManager.Ship4 != 0) {
									if (gameManager.Ship4 < 4) {
										gameManager.count4 = 0;
										gameManager.b4.SetActive(false);
									}
									gameManager.Ship4--;
									resetArray (i, j);
									//Debug.Log (gameManager.Ship4 + "");
									player1.GetComponent<Renderer> ().material = inactive;
									player1.tag = "Inactive";
								}
							}
							if (gameManager.shipIndex == 5 && gameManager.Ship5 >= 0) {
								if (gameManager.Ship5 != 0) {
									if (gameManager.Ship5 < 5) {
										gameManager.count5 = 0;
										gameManager.b5.SetActive(false);
									}
									gameManager.Ship5--;
									resetArray (i, j);
									//Debug.Log (gameManager.Ship5 + "");
									player1.GetComponent<Renderer> ().material = inactive;
									player1.tag = "Inactive";
								}
							}
						}
					}
				}
			}




		}
	}


	public bool isAdjacent(int i, int j) {

		bool result = false;
		gameManager.coord[] array = null;
		int direction = 0;

		if (gameManager.shipIndex == 1) {
			array = gameManager.ship1array;
			direction = gameManager.ship1Dir;
		}
		else if (gameManager.shipIndex == 2) {
			array = gameManager.ship2array;
			direction = gameManager.ship2Dir;
		}
		else if (gameManager.shipIndex == 3) {
			array = gameManager.ship3array;
			direction = gameManager.ship3Dir;
		}
		else if (gameManager.shipIndex == 4) {
			array = gameManager.ship4array;
			direction = gameManager.ship4Dir;
		}
		else if (gameManager.shipIndex == 5) {
			array = gameManager.ship5array;
			direction = gameManager.ship5Dir;
		}

		Debug.Log ("direction: ");
		Debug.Log(gameManager.ship4Dir);

		if(array[0].i == -1) {
			array[0].i = i; //struct?
			array[0].j = j;
			Debug.Log ("first placement");
			result = true;
		}

		else if(direction == 0) { //only one element, no direction yet
			if(i == array[0].i) {
				if(j == (array[0].j + 1)){
					array[1].i = i;
					array[1].j = j;
					direction = 2;
					Debug.Log ("second placement, new max");
					result = true;
				}
				else if (j == (array[0].j - 1)) { 
					array[1].i = array[0].i;
					array[1].j = array[0].j;
					array[0].i = i;
					array[0].j = j;
					direction = 2;
					Debug.Log ("second placement, new min");
					result = true;
				}
			}

			else if(j == array[0].j) {
				if(i == (array[0].i + 1)){
					array[1].i = i;
					array[1].j = j;
					direction = 1;
					result = true;
				}
				else if (i == (array[0].i - 1)) { 
					array[1].i = array[0].i;
					array[1].j = array[0].j;
					array[0].i = i;
					array[0].j = j;
					direction = 1;
					result = true;
				}
			}
		}

		else if(direction == 1) { //vertical
			if(j == array[0].j) {
				if(i == (array[0].i - 1)){
					array[0].i = i;
					array[0].j = j;
					result = true;
				}
				else if (i == (array[1].i + 1)) { 
					array[1].i = i;
					array[1].j = j;
					result = true;
				}
			}
		}

		else if(direction == 2) { //horizontal
			if(i == array[0].i) {
				if(j == (array[0].j - 1)){
					array[0].i = i;
					array[0].j = j;
					result = true;
				}
				else if (j == (array[1].j + 1)) { 
					array[1].i = i;
					array[1].j = j;
					result = true;
				}
			}
		}

		if (gameManager.shipIndex == 1) {
			gameManager.ship1Dir = direction;
		}
		else if (gameManager.shipIndex == 2) {
			gameManager.ship2Dir = direction;
		}
		else if (gameManager.shipIndex == 3) {
			gameManager.ship3Dir = direction;
		}
		else if (gameManager.shipIndex == 4) {
			gameManager.ship4Dir = direction;
		}
		else if (gameManager.shipIndex == 5) {
			gameManager.ship5Dir = direction;
		}

		if (result) {
			return true;
		}

		Debug.Log ("reached false");

		return false;

	}



	public void resetArray(int i, int j) {

		bool result = false;
		gameManager.coord[] array = null;
		int direction = 0;

		if (gameManager.shipIndex == 1) {
			array = gameManager.ship1array;
			direction = gameManager.ship1Dir;
		}
		else if (gameManager.shipIndex == 2) {
			array = gameManager.ship2array;
			direction = gameManager.ship2Dir;
		}
		else if (gameManager.shipIndex == 3) {
			array = gameManager.ship3array;
			direction = gameManager.ship3Dir;
		}
		else if (gameManager.shipIndex == 4) {
			array = gameManager.ship4array;
			direction = gameManager.ship4Dir;
		}
		else if (gameManager.shipIndex == 5) {
			array = gameManager.ship5array;
			direction = gameManager.ship5Dir;
		}

		/*if(direction == 0) { //only one 
			array[0].i = -1; 
			array[0].j = -1;
			Debug.Log ("first placement");
			return true;
		}*/

		if (array[0].i == i && array[0].j == j && array[1].i == -1 && array[1].j == -1) { //array is now empty
			array[0].i = -1;
			array[0].j = -1;
		}


		if (array[0].i == i && array[0].j == j) { //matches the min
			//set array[0] to new min based on direction
			if (direction == 1) {
				array[0].i += 1;
			} else if (direction == 2) {
				array[0].j += 1;
			}
		}

		else if (array[1].i == i && array[1].j == j) { //matches the max
			//set array[1] to new max based on direction
			if (direction == 1) {
				array[1].i -= 1;
			} else if (direction == 2) {
				array[1].j -= 1;
			}
		}

		if(array[0].i == array[1].i && array[0].j == array[1].j) {
			//set max to empty and direction to 0
			array[1].i = -1;
			array[1].j = -1;
			direction = 0;
		}

		if (gameManager.shipIndex == 1) {
			gameManager.ship1Dir = direction;
			gameManager.ship1array = array;
		}
		else if (gameManager.shipIndex == 2) {
			gameManager.ship2Dir = direction;
			gameManager.ship2array = array;
		}
		else if (gameManager.shipIndex == 3) {
			gameManager.ship3Dir = direction;
			gameManager.ship3array = array;
		}
		else if (gameManager.shipIndex == 4) {
			gameManager.ship4Dir = direction;
			gameManager.ship4array = array;
		}
		else if (gameManager.shipIndex == 5) {
			gameManager.ship5Dir = direction;
			gameManager.ship5array = array;
		}

	}

}  