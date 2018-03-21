using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Audio;

public class enemyManager : MonoBehaviour, IVirtualButtonEventHandler {
	public GameObject gridPoint;
	public static GameObject[,] enemyBoard;
	public static int enemyShips = 5;

	Ship ship1, ship2, ship3, ship4, ship5;

	public static int health1 = 2;
	public static int health2 = 3;
	public static int health3 = 3;
	public static int health4 = 4;
	public static int health5 = 5;

	private string shootName;
	public static bool flag = false;
	public static enemyManager instance = null;

	// shoot sound audio source
	public GameObject shootSource;
	public AudioClip shootSound;

	// use to report to GUI if hit(1) or miss(0)
	public static int reportBack = 2;

	public GameObject battleship1, battleship2, battleship3, battleship4, battleship5;

	public Material inactive = null;
	public Material active = null;
	public Material missMat = null;
	public Material hitMat = null;

	public static Material miss = null;
	public static Material hit = null;

	public static float boardY = -4.0f;

	public GameObject shootObj, vShootButton;

	void Awake() {
		/*if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad (gameObject);*/
		InitGame ();
	}

	void Start () {
		vShootButton = GameObject.Find ("VShootButton");
		if (vShootButton != null) {
			vShootButton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		}
	}

	// Use this for initialization
	void InitGame () {
		miss = missMat;
		hit = hitMat;
		int index = 0;
		enemyBoard = new GameObject[10,10];

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
				if (ToggleSettings.scaleToggle) {
					enemyBoard [i, j] = (GameObject)Instantiate (gridPoint, new Vector3 ((float)i * 3.0f, 0, (float)j * 3.0f), Quaternion.identity);
					//enemyBoard [i, j].transform.localScale = new Vector3 (0.3f, 1.0f, 0.3f);
					//enemyBoard[i, j].transform.position += new Vector3(-4, 1.0f, -6);
				} else {
					enemyBoard [i, j] = (GameObject)Instantiate (gridPoint, new Vector3 ((float)i, 0, (float)j), Quaternion.identity);
					enemyBoard[i, j].transform.localPosition += new Vector3 (2.5f, 0.0f, -5.5f);
				}
					enemyBoard[i, j].transform.parent = transform;

					enemyBoard[i, j].transform.rotation = gameManager.playerBoard[i, j].transform.rotation;
					enemyBoard[i, j].transform.localPosition = new Vector3(enemyBoard[i, j].transform.position.x, boardY, enemyBoard[i, j].transform.position.z);
                    enemyBoard[i, j].transform.localScale = gameManager.playerBoard[i, j].transform.localScale;

                    enemyBoard[i, j].name = "gridPoint" + index;
					enemyBoard [i, j].tag = "Inactive";
					enemyBoard [i, j].GetComponent<ParticleSystem> ().Pause ();
					index++;

					//place ships
					if (i == 1) {
						if (j == 1) {
							ship1 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship1;
							enemyBoard [i, j].tag = "Eship1-1";
							ship1.setHealth (3);
							ship1.setShipNum (2);
						}
						if (j == 2) {
							ship1 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship1;
							enemyBoard [i, j].tag = "Eship1-2";
						}
						if (j == 3) {
							ship1 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship1;
							enemyBoard [i, j].tag = "Eship1-3";
						}
					}
					if (i == 8) {
						if (j == 3) {
							ship3 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship3;
							enemyBoard [i, j].tag = "Eship3-1";
							ship3.setHealth(4);
							ship3.setShipNum(4);
						}
						if (j == 4) {
							ship3 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship3;
							enemyBoard [i, j].tag = "Eship3-2";
						}
						if (j == 5) {
							ship3 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship3;
							enemyBoard [i, j].tag = "Eship3-3";
						}
						if (j == 6) {
							ship3 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship3;
							enemyBoard [i, j].tag = "Eship3-4";
						}
					}
					if (j == 5) {
						if (i == 3) {
							ship2 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship2;
							enemyBoard [i, j].tag = "Eship2-1";
							ship2.setHealth (3);
							ship2.setShipNum(3);
							
						}
						if (i == 4) {
							ship2 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship2;
							enemyBoard [i, j].tag = "Eship2-2";
						}
						if (i == 5) {
							ship2 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship2;
							enemyBoard [i, j].tag = "Eship2-3";
						}
					}
					if (j == 8) {
						if (i == 5) {
							ship4 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship4;
							enemyBoard [i, j].tag = "Eship4-1";
							ship4.setHealth (5);
							ship4.setShipNum(5);
						}
						if (i == 6) {
							ship4 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship4;
							enemyBoard [i, j].tag = "Eship4-2";
						}
						if (i == 7) {
							ship4 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship4;
							enemyBoard [i, j].tag = "Eship4-3";
						}
						if (i == 8) {
							ship4 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship4;
							enemyBoard [i, j].tag = "Eship4-4";
						}
						if (i == 9) {
							ship4 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship4;
							enemyBoard [i, j].tag = "Eship4-5";
						}
					}
					if (j == 9) {
						if (i == 2) {
							ship5 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship5;
							enemyBoard [i, j].tag = "Eship5-1";
							ship5.setHealth (2);
							ship5.setShipNum(1);
						}
						if (i == 3) {
							ship5 = enemyBoard [i, j].AddComponent<Ship> () as Ship;
							//enemyBoard[i,j].GetComponents<Ship> = ship5;
							enemyBoard [i, j].tag = "Eship5-2";
						}
					}
				}
			}
			
	}
	
	// Update is called once per frame
	// render misses and hits
	void Update () {
		if (health1 < 0) {
			Debug.Log ("show ship 1");
			this.transform.GetChild(0).gameObject.SetActive (true);
			this.transform.GetChild (0).gameObject.transform.localPosition = new Vector3 (2.64f, -3.32f, 0.94f);
			if (ToggleSettings.scaleToggle) {
				this.transform.GetChild (0).gameObject.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			}
		}
		if (health2 < 0) {
			this.transform.GetChild(1).gameObject.SetActive (true);
			this.transform.GetChild (1).gameObject.transform.localPosition = new Vector3 (3.87f, -3.28f, -2.1f);
			if (ToggleSettings.scaleToggle) {
				this.transform.GetChild (1).gameObject.transform.localScale = new Vector3 (0.07f, 0.07f, 0.07f);
			}
		}
		if (health3 < 0) {
			this.transform.GetChild(2).gameObject.SetActive (true);
			this.transform.GetChild (2).gameObject.transform.localPosition = new Vector3 (1.36f, -3.25f, -4.08f);
			if (ToggleSettings.scaleToggle) {
				this.transform.GetChild (2).gameObject.transform.localScale = new Vector3 (0.07f, 0.07f, 0.07f);
			}
		}
		if (health4 < 0) {
			this.transform.GetChild(3).gameObject.SetActive (true);
			this.transform.GetChild (3).gameObject.transform.localPosition = new Vector3 (6.75f, -3.12f, -2.21f);
			if (ToggleSettings.scaleToggle) {
				this.transform.GetChild (3).gameObject.transform.localScale = new Vector3 (0.08f, 0.08f, 0.08f);
			}
		}
		if (health5 < 0) {
			Debug.Log ("show ship 5");
			this.transform.GetChild(4).gameObject.SetActive (true);
			this.transform.GetChild (4).gameObject.transform.localPosition = new Vector3 (6.04f, -3.16f, -2.1f);
			if (ToggleSettings.scaleToggle) {
				this.transform.GetChild (4).gameObject.transform.localScale = new Vector3 (0.07f, 0.07f, 0.07f);
			}
		}
		if (enemyShips == 0) {
			//go to win scene
			Debug.Log("Player win");
			//Destroy(gameObject.transform.parent.transform.parent);
			Color color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
			Destroy(Loader.GameManager);
			Initiate.Fade("WinScene", color, 0.8f);
			//Application.LoadLevel("GameOver");
		}
		Debug.Log (health1);
		Debug.Log (health2);
		Debug.Log (health3);
		Debug.Log (health4);
		Debug.Log (health5);
	}
		
	public static bool isShipHit(GameObject selection) {
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				//find specific ship
				if (selection.tag.CompareTo(enemyBoard[i,j].tag) == 0) {
					if (selection.tag.Contains ("Eship1")) {
						health3--;
					}
					if (selection.tag.Contains ("Eship2")) {
						health2--;
					}
					if (selection.tag.Contains ("Eship3")) {
						health4--;
					}
					if (selection.tag.Contains ("Eship4")) {
						health5--;
					}
					if (selection.tag.Contains ("Eship5")) {
						health1--;
					}

					enemyBoard[i, j].tag = "hit";
					enemyBoard[i, j].GetComponent<Ship>().takeDamage();
					enemyBoard[i, j].GetComponent<ParticleSystem>().Play();
					enemyBoard[i,j].GetComponent<Renderer>().material = hit;
					isShipSunk (enemyBoard[i, j].GetComponent<Ship>());
					var shipComponent = enemyBoard [i, j].GetComponent<Ship>();
					Destroy(shipComponent);
					return true;
				}
			}
		}
		return false;
	}

	public static void isShipSunk(Ship ship) {
		if (health1 == 0) {
			enemyShips--;
			health1 = -1;
			Debug.Log ("One less ship");
		}
		if (health2 == 0) {
			enemyShips--;
			health2 = -1;
			Debug.Log ("One less ship");
		}
		if (health3 == 0) {
			enemyShips--;
			health3 = -1;
			Debug.Log ("One less ship");
		}
		if (health4 == 0) {
			enemyShips--;
			health4 = -1;
			Debug.Log ("One less ship");
		}
		if (health5 == 0) {
			enemyShips--;
			health5 = -1;
			Debug.Log ("One less ship");
		}
	}

	// function for button, check if ship is sunk
	// if no hit, make "Miss!" appear and OK button to move to playerBoard scene
	// if all ships are sunk go to gameOver scene
	public void shoot() {

		shootSource.GetComponent<AudioSource> ().PlayOneShot (shootSound);

		// check if target is a ship
		if (ToggleSettings.selectionToggle) {
			if (IndirectSelection.target.tag.StartsWith("Eship")) {
				if (isShipHit (IndirectSelection.target)) {
					//flag = false;
					reportBack = 1;
					Debug.Log(IndirectSelection.target.name);
					IndirectSelection.chosenSpot = false;
				}
			} else {
				//pop up "Miss!"
				//flag = false;
				reportBack = 0;
				IndirectSelection.target.tag = "miss";
				Debug.Log("Miss1!");
				IndirectSelection.target.GetComponent<Renderer>().material = miss;
				//Application.DontDestroyOnLoad(Application.);
				//Application.DontDestroyOnLoad (notLoaded2);
				IndirectSelection.chosenSpot = false;
				//Application.LoadLevel("playerBoard");
			}
		} else {
			if (PlayerShoot.chosenSpot == false) {
				Debug.Log ("No spot selected.");
			}
			else if (PlayerShoot.targetedShip.tag.StartsWith("Eship")) {
				if (isShipHit (PlayerShoot.targetedShip)) {
					reportBack = 1;
					flag = false;
					Debug.Log(PlayerShoot.targetedShip.name);
					PlayerShoot.chosenSpot = false;
				}
			} else {
				//pop up "Miss!"
				reportBack = 0;
				flag = false;
				GUIEnemyBoard.second = true;
				PlayerShoot.targetedShip.tag = "miss";
				Debug.Log("Miss!");
				PlayerShoot.targetedShip.GetComponent<Renderer>().material = miss;
				//Application.DontDestroyOnLoad(Application.);
				//Application.DontDestroyOnLoad (notLoaded2);
				PlayerShoot.chosenSpot = false;
				//Application.LoadLevel("playerBoard");
			}
		}
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "VShootButton") {
			if (ToggleSettings.UiToggle) {
				// Decrease Y scale to make button look pressed
				shootObj.transform.localScale = new Vector3(0.7692308f, 0.5f, 0.7692308f);
			}
		}

		Debug.Log ("Pressed");
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb) {
		if (vb.gameObject.name == "VShootButton") {
			if (ToggleSettings.UiToggle) {
				// Increase Y scale to make button look released
				shootObj.transform.localScale = new Vector3(0.7692308f, 1.2f, 0.7692308f);
				// shoot
				shoot();
			}
		}
		Debug.Log ("Released");
	}


}



public class Ship : MonoBehaviour {
	public int health = 0;
	public bool isDead = false;
	public int shipNum = 0;

	public void setShipNum(int num) {
		shipNum = num;
	}

	public void setHealth(int size) {
		health = size;
	}

	public void takeDamage() {
		health--;
	}

	public bool isSunk() {
		if (health <= 0) {
			return true;
		} else
			return false;
	}
}
