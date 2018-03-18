using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
	public GameObject gridPoint;
	public static GameObject[,] playerBoard;
	public static int playerShips = 5;
	public static int shipIndex;
	public static bool flag = false;
	public string level;
	public static gameManager instance = null;

	public static Ship ship1, ship2, ship3, ship4, ship5;

	public GameObject battleship1, battleship2, battleship3, battleship4, battleship5;

	public static GameObject b1, b2, b3, b4, b5;

	public static Transform shipTransform1, shipTransform2, shipTransform3, shipTransform4, shipTransform5;

	public static int Ship1 = 0;
	public static int Ship2 = 0;
	public static int Ship3 = 0;
	public static int Ship4 = 0;
	public static int Ship5 = 0;

	public static int ship1Dir = 0;
	public static int ship2Dir = 0;
	public static int ship3Dir = 0;
	public static int ship4Dir = 0;
	public static int ship5Dir = 0;

	public static int count1 = 0;
	public static int count2 = 0;
	public static int count3 = 0;
	public static int count4 = 0;
	public static int count5 = 0;

	public struct coord {
		public int i;
		public int j;

		public coord(int i, int j) {
			this.i = i;
			this.j = j;
		}
	};

	public static coord[] ship1array = new coord[] { new coord() {i = -1, j = -1}, new coord() {i = -1, j = -1} };
	public static coord[] ship2array = new coord[] { new coord() {i = -1, j = -1}, new coord() {i = -1, j = -1} };
	public static coord[] ship3array = new coord[] { new coord() {i = -1, j = -1}, new coord() {i = -1, j = -1} };
	public static coord[] ship4array = new coord[] { new coord() {i = -1, j = -1}, new coord() {i = -1, j = -1} };
	public static coord[] ship5array = new coord[] { new coord() {i = -1, j = -1}, new coord() {i = -1, j = -1} };

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			// Destroy (gameObject.transform.parent.transform.parent);
			Destroy (gameObject.transform.parent);
		}
		//DontDestroyOnLoad (gameObject.transform.parent.transform.parent);
		DontDestroyOnLoad (gameObject.transform.parent);
		InitGame ();
	}


	// Use this for initialization
	void InitGame() {

		//    DontDestroyOnLoad(gameManager.playerBoard);
		playerBoard = new GameObject[10,10];
		int indexOfBoard = 0;

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				if (ToggleSettings.scaleToggle) {
					playerBoard[i,j] = (GameObject)Instantiate (gridPoint, new Vector3 ((float)i * 3.0f, 0, (float)j * 3.0f), Quaternion.identity);
					playerBoard [i, j].transform.localScale = new Vector3 (0.3f, 1.0f, 0.3f);
					playerBoard[i, j].transform.position += new Vector3 (-4, 1.5f, -6);
				} else {
					playerBoard[i,j] = (GameObject)Instantiate (gridPoint, new Vector3 ((float)i, 0, (float)j), Quaternion.identity);
					playerBoard[i, j].transform.position += new Vector3 (-1.5f, 0.0f, -8.5f);
				}

                playerBoard[i,j].transform.parent = transform;

                playerBoard[i, j].transform.position = new Vector3(playerBoard[i, j].transform.position.x, 18f, playerBoard[i, j].transform.position.z);

                playerBoard[i,j].transform.name = "gridPoint" + indexOfBoard;
				playerBoard [i, j].tag = "Inactive";
				playerBoard[i,j].SetActive (true);
				indexOfBoard++;
			}
		}

        /*b1 = battleship1;
		b2 = battleship2;
		b3 = battleship3;
		b4 = battleship4;
		b5 = battleship5;*/

		b1 = this.gameObject.transform.GetChild (0).gameObject;
		b2 = this.gameObject.transform.GetChild (1).gameObject;
		b3 = this.gameObject.transform.GetChild (2).gameObject;
		b4 = this.gameObject.transform.GetChild (3).gameObject;
		b5 = this.gameObject.transform.GetChild (4).gameObject;

		if (ToggleSettings.scaleToggle) {
			b1.transform.localScale = new Vector3 (8.0f, 8.0f, 8.0f);
			b2.transform.localScale = new Vector3 (5.0f, 5.0f, 5.0f);
			b3.transform.localScale = new Vector3 (5.0f, 5.0f, 5.0f);
			b4.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
			b5.transform.localScale = new Vector3 (5.0f, 5.0f, 5.0f);
		}
	}

	public void DonePlacingShips()
	{
		//Application.DontDestroyOnLoad (playerBoard);
		//Application.DontDestroyOnLoad (notLoaded);
		if (count1 == 1 && count2 == 1 && count3 == 1 && count4 == 1 && count5 == 1) {
			Color color = new Color (0.2f, 0.2f, 0.2f, 1.0f);
			Initiate.Fade("enemyBoard", color, 2.0f);
		}
		//Application.LoadLevel("enemyBoard");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void ActivateShip1Selection()
	{
		shipIndex = 1;
	}
	public void ActivateShip2Selection()
	{
		shipIndex = 2;
	}
	public void ActivateShip3Selection()
	{
		shipIndex = 3;
	}
	public void ActivateShip4Selection()
	{
		shipIndex = 4;
	}
	public void ActivateShip5Selection()
	{
		shipIndex = 5;
	}
} 