using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
	public GameObject gridPoint;
	public static GameObject[,] playerBoard;
	public static int playerShips = 5;
	public static int shipIndex;
	public static bool flag = false;
	public string level;
	public static gameManager instance = null;

	public static Ship ship1;
	public static Ship ship2;
	public static Ship ship3;
	public static Ship ship4;
	public static Ship ship5;

	public GameObject battleship1;
	public GameObject battleship2;
	public GameObject battleship3;
	public GameObject battleship4;
	public GameObject battleship5;

	public static GameObject b1;
	public static GameObject b2;
	public static GameObject b3;
	public static GameObject b4;
	public static GameObject b5;

	public static Transform shipTransform1;
	public static Transform shipTransform2;
	public static Transform shipTransform3;
	public static Transform shipTransform4;
	public static Transform shipTransform5;

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
			Destroy (gameObject.transform.parent.transform.parent);
		}
		DontDestroyOnLoad (gameObject.transform.parent.transform.parent);
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
					playerBoard[i, j].transform.position += new Vector3 (-14.0f, 1.0f, -3.0f);
				} else {
					playerBoard[i,j] = (GameObject)Instantiate (gridPoint, new Vector3 ((float)i, 0, (float)j), Quaternion.identity);
					playerBoard[i, j].transform.position += new Vector3 (-4.0f, 1.0f, 6.0f);
				}
				playerBoard[i,j].transform.parent = transform;
				playerBoard[i,j].transform.name = "gridPoint" + indexOfBoard;
				playerBoard [i, j].tag = "Inactive";
				playerBoard[i,j].SetActive (true);
				indexOfBoard++;
			}
		}
		b1 = battleship1; // Submarine
		b2 = battleship2; // Scout
		b3 = battleship3; // Transport
		b4 = battleship4; // Battleship
		b5 = battleship5; // Aircraft Carrier
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

	// Update is called once per frame
	void Update () {

	}


} 