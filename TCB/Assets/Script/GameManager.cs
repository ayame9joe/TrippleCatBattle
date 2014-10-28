using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	
	public GameObject cat;
	public GameObject enemy;

	int numOfCats = 3;
	bool startTimer = true;

	Vector3 position1 = new Vector3(-360, -200, 0);
	Vector3 position2 = new Vector3(-300, -200, 0);
	Vector3 position3 = new Vector3(-240, -200, 0);

	public static bool isP1Available = true;
	public static bool isP2Available = true;
	public static bool isP3Available = true;

	int serialNumber = 0;

	public static float widthOfWindow = 800;
	public static float heightOfWindow = 480;

	public static int numOfBomb = 0;
	public static int numOfShot = 0;
	public static int numOfHeal = 0;

	float bombX;
	float bombY;
	float healX;
	float healY;
	float shotX;
	float shotY;
	//int enemySerial = 0;

	public static int bombLevel = 1;
	public static int healLevel = 1;
	public static int shotLevel = 1;

	bool newBomb;
	bool newHeal;
	bool newShot;

	public static int putBombs;
	public static int putHeals;
	public static int putShots;


	bool bombCabin1;
	bool bombCabin2;
	bool bombCabin3;
	bool bombCabin4;

	bool noBombCabin1 = true;
	bool noBombCabin2 = true;
	bool noBombCabin3 = true;
	bool noBombCabin4 = true;

	bool healCabin1;
	bool healCabin2;
	bool healCabin3;
	bool healCabin4;
	
	bool noHealCabin1 = true;
	bool noHealCabin2 = true;
	bool noHealCabin3 = true;
	bool noHealCabin4 = true;

	bool shotCabin1;
	bool shotCabin2;
	bool shotCabin3;
	bool shotCabin4;
	
	bool noShotCabin1 = true;
	bool noShotCabin2 = true;
	bool noShotCabin3 = true;
	bool noShotCabin4 = true;

	public static bool recal;

	GameObject newBombGo;
	GameObject newShotGo;
	GameObject newHealGo;

	bool numOfBombToZero;
	bool numOfShotToZero;
	bool numOfHealToZero;

	GameObject[] go;

	public static List<GameObject> cabin1cats = new List<GameObject> ();
	public static List<GameObject> cabin2cats = new List<GameObject> ();
	public static List<GameObject> cabin3cats = new List<GameObject> ();
	public static List<GameObject> cabin4cats = new List<GameObject> ();

	public static int maxDistance;

	public Text txtDistance;

	void Awake ()
	{
		Screen.SetResolution (800, 480, true);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine("DisCal");
	}
	
	// Update is called once per frame
	void Update () {


		txtDistance.text = maxDistance.ToString();
		//Debug.Log (startTimer);
		if (GameObject.Find ("Ship").GetComponent<Health> ().health == 0 || 
		    GameObject.Find ("Ship").GetComponent<Health> ().health < 0) {
			Restart();


		}
		//Debug.Log ("bombPut:" + Cabin.bombPut);
		//Debug.Log ("numOfBomb:" + numOfBomb);
		//Debug.Log ("Put Bombs:" + putBombs);
		//Debug.Log ("numOfHeal:" + numOfHeal);
		//Debug.Log ("numOfShot:" + numOfShot);
		Debug.Log (cabin1cats.Count);
		if (cabin1cats.Count > 1)
		{
			int i = 0;
			//Debug.Log (cabin1cats[i].GetComponent<Cat>().die);
			//if (cabin1cats[i+1])
			{

//				if (cabin1cats[i+1].GetComponent<Cat>().Shoot)
					//if (others[i+1].GetComponent<Cat>().Shoot)
				{

					//Debug.Log("i:" + i);
					if (cabin1cats[i])
					{
						if (cabin1cats[i].GetComponent<Cat>().die)
						{
							cabin1cats.Remove(cabin1cats[i]);
						}

						if (cabin1cats[i].GetComponent<Cat>().transform.localPosition != Defines.cabin1)
						{
							cabin1cats.Remove(cabin1cats[i]);
						}
						cabin1cats[i].GetComponent<Cat>().waitForDestroy = 0.02f;
						cabin1cats[i].GetComponent<Cat>().die = true;
						
						cabin1cats.Remove(cabin1cats[i]);
						i++;
					}
				}
			}
		}
		if (cabin2cats.Count > 1)
		{
			int i = 0;
			
			//if (cabin1cats[i+1])
			{

				//if (cabin2cats[i+1].GetComponent<Cat>().Shoot)
					//if (others[i+1].GetComponent<Cat>().Shoot)
				{

					
					if (cabin2cats[i])
					{

						
						cabin2cats[i].GetComponent<Cat>().waitForDestroy = 0.02f;
						cabin2cats[i].GetComponent<Cat>().die = true;
						
						cabin2cats.Remove(cabin2cats[i]);
						i++;
					}
				}
			}
		}
		if (cabin3cats.Count > 1)
		{
			int i = 0;
			
			//if (cabin1cats[i+1])
			{

				//if (cabin1cats[i+1].GetComponent<Cat>().Shoot)
					//if (others[i+1].GetComponent<Cat>().Shoot)
				{

					
					if (cabin3cats[i])
					{
						cabin3cats[i].GetComponent<Cat>().waitForDestroy = 0.02f;
						cabin3cats[i].GetComponent<Cat>().die = true;
						
						cabin3cats.Remove(cabin3cats[i]);
						i++;
					}
				}
			}
		}
		if (cabin4cats.Count > 1)
		{
			int i = 0;
			
			//if (cabin1cats[i+1])
			{

				//if (cabin4cats[i+1].GetComponent<Cat>().Shoot)
					//if (others[i+1].GetComponent<Cat>().Shoot)
				{

					
					if (cabin4cats[i])
					{

						
						cabin4cats[i].GetComponent<Cat>().waitForDestroy = 0.02f;
						cabin4cats[i].GetComponent<Cat>().die = true;
						
						cabin4cats.Remove(cabin4cats[i]);
						i++;
					}
				}
			}
		}
		if (startTimer) {
			StartCoroutine (CatsGenerating ());
			startTimer = false;
		}
		
		if (serialNumber > 2) {
			serialNumber = 0;		
		}
		
		
		Invoke ("EnemiesGenerating", Random.Range (0.5f, 3));	

		go = GameObject.FindGameObjectsWithTag ("Cat");

		BombMerge ();
		ShotMerge ();
		HealMerge ();


				


	}

	IEnumerator CatsGenerating ()
	{
		yield return new WaitForSeconds (0);

		GameObject go;

	//	for (int i = 0; i < numOfCats; i++) {
		switch(serialNumber)
		{
		case 0:
			Debug.Log("Cats Generating");

			if (!isP1Available) {
				serialNumber++;		
			}
			else
			{
				go = Instantiate(cat, transform.position, transform.rotation) as GameObject;
				go.transform.parent = GameObject.Find("Cats").transform;
				go.transform.localPosition = position1;
				serialNumber++;

			}
			break;
		case 1:


			if (!isP2Available) {
				serialNumber++;		
			}
			else {
				go = Instantiate(cat, transform.position, transform.rotation) as GameObject;
				go.transform.parent = GameObject.Find("Cats").transform;
				go.transform.localPosition = position2;
				serialNumber++;
			}
			break;
		case 2:


			if (!isP3Available) {
				serialNumber++;		
			}
			else 
			{
				go = Instantiate(cat, transform.position, transform.rotation) as GameObject;
				go.transform.parent = GameObject.Find("Cats").transform;
				go.transform.localPosition = position3;
				serialNumber++;
			}
			break;
		}



		startTimer = true;


		//}

	}

	void EnemiesGenerating ()
	{
		//yield return new WaitForSeconds (5);
		GameObject go = GameObject.Instantiate (enemy, new Vector3 (GameManager.widthOfWindow, Random.Range (GameManager.heightOfWindow / 2 - 125, GameManager.heightOfWindow / 2 + 125), 0), this.transform.rotation) as GameObject;
		go.transform.parent = GameObject.Find("Enemies").transform;
		CancelInvoke ();
	}

	void NewBomb()
	{
		newBombGo = Instantiate(cat, transform.position, transform.rotation) as GameObject;
		newBombGo.transform.parent = GameObject.Find("Cats").transform;
		newBombGo.transform.localPosition = new Vector3(bombX, bombY, 0);
		newBombGo.GetComponent<Cat>().Shoot = true;
		newBombGo.GetComponent<Cat>().Level = bombLevel;
		newBombGo.GetComponent<Cat>().catsRandom = false;
		newBombGo.GetComponent<Cat>().catsType = Cat.CatsType.Bomb;
		newBombGo.GetComponent<Cat> ().die = false;
		numOfBombToZero = false;

		if (newBombGo.GetComponent<Cat> ().die)
		{
			if (bombX == Defines.cabin1.x && bombY == Defines.cabin1.y)
			{
				Debug.Log("Bomb die");
				GameManager.cabin1cats.Remove(newBombGo.gameObject);
			}
			if (bombX == Defines.cabin2.x && bombY == Defines.cabin2.y)
				GameManager.cabin2cats.Remove(newBombGo.gameObject);
			if (bombX == Defines.cabin3.x && bombY == Defines.cabin3.y)
				GameManager.cabin3cats.Remove(newBombGo.gameObject);
			if (bombX == Defines.cabin4.x && bombY == Defines.cabin4.y)
				GameManager.cabin4cats.Remove(newBombGo.gameObject);
		}

		if (bombX == Defines.cabin1.x && bombY == Defines.cabin1.y)
			GameManager.cabin1cats.Add(newBombGo.gameObject);
		if (bombX == Defines.cabin2.x && bombY == Defines.cabin2.y)
			GameManager.cabin2cats.Add(newBombGo.gameObject);
		if (bombX == Defines.cabin3.x && bombY == Defines.cabin3.y)
			GameManager.cabin3cats.Add(newBombGo.gameObject);
		if (bombX == Defines.cabin4.x && bombY == Defines.cabin4.y)
			GameManager.cabin4cats.Add(newBombGo.gameObject);
		
		
		
	}
	
	void NewShot()
	{
		newShotGo = Instantiate(cat, transform.position, transform.rotation) as GameObject;
		newShotGo.transform.parent = GameObject.Find("Cats").transform;
		newShotGo.transform.localPosition = new Vector3(shotX, shotY, 0);
		newShotGo.GetComponent<Cat>().Shoot = true;
		newShotGo.GetComponent<Cat>().Level = shotLevel;
		newShotGo.GetComponent<Cat>().catsRandom = false;
		newShotGo.GetComponent<Cat> ().catsType = Cat.CatsType.Shot;
		newShotGo.GetComponent<Cat> ().die = false;
		numOfShotToZero = false;

		if (newShotGo.GetComponent<Cat> ().die)
		{
			if (shotX == Defines.cabin1.x && shotY == Defines.cabin1.y)
				GameManager.cabin1cats.Remove(newShotGo.gameObject);
			if (shotX == Defines.cabin2.x && shotY == Defines.cabin2.y)
				GameManager.cabin2cats.Remove(newShotGo.gameObject);
			if (shotX == Defines.cabin3.x && shotY == Defines.cabin3.y)
				GameManager.cabin3cats.Remove(newShotGo.gameObject);
			if (shotX == Defines.cabin4.x && shotY == Defines.cabin4.y)
				GameManager.cabin4cats.Remove(newShotGo.gameObject);
		}

		if (shotX == Defines.cabin1.x && shotY == Defines.cabin1.y)
			GameManager.cabin1cats.Add(newShotGo.gameObject);
		if (shotX == Defines.cabin2.x && shotY == Defines.cabin2.y)
			GameManager.cabin2cats.Add(newShotGo.gameObject);
		if (shotX == Defines.cabin3.x && shotY == Defines.cabin3.y)
			GameManager.cabin3cats.Add(newShotGo.gameObject);
		if (shotX == Defines.cabin4.x && shotY == Defines.cabin4.y)
			GameManager.cabin4cats.Add(newShotGo.gameObject);
		
		
	}

	void NewHeal()
	{
		newHealGo = Instantiate(cat, transform.position, transform.rotation) as GameObject;
		newHealGo.transform.parent = GameObject.Find("Cats").transform;
		newHealGo.transform.localPosition = new Vector3(healX, healY, 0);
		newHealGo.GetComponent<Cat>().Shoot = true;
		newHealGo.GetComponent<Cat>().Level = healLevel;
		newHealGo.GetComponent<Cat>().catsRandom = false;
		newHealGo.GetComponent<Cat>().catsType = Cat.CatsType.Heal;
		newHealGo.GetComponent<Cat> ().die = false;
		numOfHealToZero = false;
		
		if (newHealGo.GetComponent<Cat> ().die)
		{
			if (healX == Defines.cabin1.x && healY == Defines.cabin1.y)
				GameManager.cabin1cats.Remove(newHealGo.gameObject);
			if (healX == Defines.cabin2.x && healY == Defines.cabin2.y)
				GameManager.cabin2cats.Remove(newHealGo.gameObject);
			if (healX == Defines.cabin3.x && healY == Defines.cabin3.y)
				GameManager.cabin3cats.Remove(newHealGo.gameObject);
			if (healX == Defines.cabin4.x && healY == Defines.cabin4.y)
				GameManager.cabin4cats.Remove(newHealGo.gameObject);
		}
		if (healX == Defines.cabin1.x && healY == Defines.cabin1.y)
			GameManager.cabin1cats.Add(newHealGo.gameObject);
		if (healX == Defines.cabin2.x && healY == Defines.cabin2.y)
			GameManager.cabin2cats.Add(newHealGo.gameObject);
		if (healX == Defines.cabin3.x && healY == Defines.cabin3.y)
			GameManager.cabin3cats.Add(newHealGo.gameObject);
		if (healX == Defines.cabin4.x && healY == Defines.cabin4.y)
			GameManager.cabin4cats.Add(newHealGo.gameObject);
		
	}

	void BombMerge ()
	{
		if (newBombGo != null) {
			//Debug.Log("New Bomb");
			
			/*if (newBombGo.GetComponent<Cat> ().die) {
				if (!numOfBombToZero) {
					numOfBomb--;
					numOfBombToZero = true;
				}
			}*/
		}
		
		if (bombLevel > 10) {
			bombLevel = 10;		
		}
		

		

		List<GameObject> bombs = new List<GameObject> ();
		for (int i = 0; i < go.Length; i++) {
			if (go [i].GetComponent<Cat> ().catsType == Cat.CatsType.Bomb) {
				if (go [i].GetComponent<Cat> ().Shoot == true) {
					bombs.Add (go [i]);
					//Debug.Log(i);
				}
				
				
			}
		}

		//Debug.Log (bombs.Count);;
		if (Cabin.bombPut == 0) {
			//heals.Clear();	
			bombY = 0;
			bombX = 0;
		}
		for (int i = 0; i < bombs.Count; i++) {
			
			/*if (bombs [i].transform.localPosition.y < bombY) {
				bombY = bombs [i].transform.localPosition.y;
			}*/

			bombX = bombs[bombs.Count - 1].transform.localPosition.x;
			bombY = bombs[bombs.Count - 1].transform.localPosition.y;
			//Debug.Log(bombs[i].transform.localPosition.y);
			
			
			if (numOfBomb == 3) {
				
				recal = true;
				/*if (bombLevel < 2) {
					numOfBomb = 0;
				} else {
					numOfBomb = 1;
				}*/
				//bombs.RemoveAt(i);
				//numOfBomb = 0;
				
				Cat.levelUp = true;
				bombLevel = bombs [i].GetComponent<Cat> ().Level;
				bombLevel++;
				//Debug.Log(bombLevel);
				newBomb = true;
				//bombs.RemoveAt(i);
				//bombs.Clear();
				
			}
			
			if (newBomb) {
				if (bombs [i].GetComponent<Cat> ().putPosition == Defines.cabin1) {
					if (!noBombCabin1) {
						Cat.catsOutOfCabin1--;
						cabin1cats.Remove(bombs[i].gameObject);
						noBombCabin1 = true;
					}
				}
				if (bombs [i].GetComponent<Cat> ().putPosition == Defines.cabin2) {
					if (!noBombCabin2) {
						Cat.catsOutOfCabin2--;
						cabin2cats.Remove(bombs[i].gameObject);
						noBombCabin2 = true;
					}
				}
				if (bombs [i].GetComponent<Cat> ().putPosition == Defines.cabin3) {
					if (!noBombCabin3) {
						Cat.catsOutOfCabin3--;
						cabin3cats.Remove(bombs[i].gameObject);
						noBombCabin3 = true;
					}
				}
				if (bombs [i].GetComponent<Cat> ().putPosition == Defines.cabin4) {
					if (!noBombCabin4) {
						Cat.catsOutOfCabin4--;
						cabin4cats.Remove(bombs[i].gameObject);
						noBombCabin4 = true;
					}
				}
				
				if (bombY == Defines.cabin4.y && bombX == Defines.cabin4.x) {
					if (!bombCabin4) {
						if (bombLevel < 3) {
							Cat.catsOutOfCabin4 += 1;
						} else {
							Cat.catsOutOfCabin4 += 2;
							
						}
						bombCabin4 = true;
						
					}
					
					
				}
				if (bombY == Defines.cabin1.y && bombX == Defines.cabin1.x) {
					if (!bombCabin1) {
						if (bombLevel < 3) {
							Cat.catsOutOfCabin1 += 1;
						} else {
							Cat.catsOutOfCabin1 += 2;
							
						}
						bombCabin1 = true;
						//GameManager.cabin1cats.Add(this.gameObject);

					}
				}
				if (bombY == Defines.cabin2.y && bombX == Defines.cabin2.x) {
					if (!bombCabin2) {
						if (bombLevel < 3) {
							Cat.catsOutOfCabin2 += 1;
						} else {
							Cat.catsOutOfCabin2 += 2;
							
						}
						bombCabin2 = true;
					}
				}
				if (bombY == Defines.cabin3.y && bombX == Defines.cabin3.x) {
					if (!bombCabin3) {
						if (bombLevel < 3) {
							Cat.catsOutOfCabin3 += 1;
						} else {
							Cat.catsOutOfCabin3 += 2;
							
						}
						bombCabin3 = true;
					}
				}
				
				bombs [i].transform.localPosition = Vector3.MoveTowards (
					bombs [i].transform.localPosition, 
					new Vector3 (bombX, bombY, 0),
					20);
				
				
				bombs [i].GetComponent<Cat> ().die = true;
				
				if (bombs [i].transform.localPosition == new Vector3 (bombX, bombY, 0)) {
					putBombs++;
					//Debug.Log(putBombs);
					//newBomb = true;
				}
				
				if (putBombs == 3) {
					recal = false;
					NewBomb ();
					newBomb = false;
					bombCabin1 = false;
					bombCabin2 = false;
					bombCabin3 = false;
					bombCabin4 = false;
					noBombCabin1 = false;
					noBombCabin2 = false;
					noBombCabin3 = false;
					noBombCabin4 = false;
					//numOfBomb--;
					putBombs = 0;
					
					
					
				}
				
				
				//else {newBomb = false;}
				
				//newBomb = false;
				
				
				
			}
			
			
			
			
			//numOfBomb = 1;
			//numOfBomb -= bombs.Count - 1;
			
			
			//Destroy(bombs[i].gameObject);
		}
	}


	void ShotMerge ()
	{
		if (newShotGo != null) {
			//Debug.Log("New Bomb");
			
			if (newShotGo.GetComponent<Cat> ().die) {
				/*if (!numOfShotToZero) {
					numOfShot--;
					numOfShotToZero = true;
				}*/
			}
		}
		
		if (shotLevel > 10) {
			shotLevel = 10;		
		}
		//Debug.Log ("Bomb:" + numOfBomb);
		//Debug.Log ("Heal:" + numOfHeal);
		//Debug.Log ("Shot:" + numOfShot);
		//Debug.Log (serialNumber);
		
		List<GameObject> shots = new List<GameObject> ();
		for (int i = 0; i < go.Length; i++) {
			if (go [i].GetComponent<Cat> ().catsType == Cat.CatsType.Shot) {
				if (go [i].GetComponent<Cat> ().Shoot == true) {
					shots.Add (go [i]);
					
				}
				
				
			}
		}
		
		if (Cabin.shotPut == 0) {
			//heals.Clear();	
			shotY = 0;
			shotX = 0;
		}
		for (int i = 0; i < shots.Count; i++) {
			
			/*if (shots [i].transform.localPosition.y < shotY) {
				shotY = shots [i].transform.localPosition.y;
			}*/

			//Debug.Log(bombs[i].transform.localPosition.y);

			shotX = shots[shots.Count - 1].transform.localPosition.x;
			shotY = shots[shots.Count - 1].transform.localPosition.y;
			
			if (numOfShot == 3) {
				
				recal = true;
				/*if (shotLevel < 2) {
					if (numOfShot != 0)
					{
						numOfShot = 0;
					}
				} else {
					if (numOfShot != 0)
					{
						numOfShot = 1;
					}
				}*/
				//bombs.RemoveAt(i);
				//numOfBomb = 0;
				
				Cat.levelUp = true;
				shotLevel = shots [i].GetComponent<Cat> ().Level;
				shotLevel++;
				//Debug.Log(bombLevel);
				newShot = true;
				//bombs.RemoveAt(i);
				//bombs.Clear();
				
			}
			
			if (newShot) {
				if (shots [i].GetComponent<Cat> ().putPosition == Defines.cabin1) {
					if (!noShotCabin1) {
						Cat.catsOutOfCabin1--;
						cabin1cats.Remove(shots[i].gameObject);
						noShotCabin1 = true;
					}
				}
				if (shots [i].GetComponent<Cat> ().putPosition == Defines.cabin2) {
					if (!noShotCabin2) {
						Cat.catsOutOfCabin2--;
						cabin2cats.Remove(shots[i].gameObject);
						noShotCabin2 = true;
					}
				}
				if (shots [i].GetComponent<Cat> ().putPosition == Defines.cabin3) {
					if (!noShotCabin3) {
						Cat.catsOutOfCabin3--;
						cabin3cats.Remove(shots[i].gameObject);
						noShotCabin3 = true;
					}
				}
				if (shots [i].GetComponent<Cat> ().putPosition == Defines.cabin4) {
					if (!noShotCabin4) {
						Cat.catsOutOfCabin4--;
						cabin4cats.Remove(shots[i].gameObject);
						noShotCabin4 = true;
					}
				}
				
				if (shotY == Defines.cabin4.y && shotX == Defines.cabin4.x) {
					if (!shotCabin4) {
						if (shotLevel < 3) {
							Cat.catsOutOfCabin4 += 1;
						} else {
							Cat.catsOutOfCabin4 += 2;
							
						}
						shotCabin4 = true;
						
					}
					
					
				}
				if (shotY == Defines.cabin1.y  && shotX == Defines.cabin1.x) {
					if (!shotCabin1) {
						if (shotLevel < 3) {
							Cat.catsOutOfCabin1 += 1;
						} else {
							Cat.catsOutOfCabin1 += 2;
							
						}
						shotCabin1 = true;
					}
				}
				if (shotY == Defines.cabin2.y  && shotX == Defines.cabin2.x) {
					if (!shotCabin2) {
						if (shotLevel < 3) {
							Cat.catsOutOfCabin2 += 1;
						} else {
							Cat.catsOutOfCabin2 += 2;
							
						}
						shotCabin2 = true;
					}
				}
				if (shotY == Defines.cabin3.y  && shotX == Defines.cabin3.x) {
					if (!shotCabin3) {
						if (shotLevel < 3) {
							Cat.catsOutOfCabin3 += 1;
						} else {
							Cat.catsOutOfCabin3 += 2;
							
						}
						shotCabin3 = true;
					}
				}
				
				shots [i].transform.localPosition = Vector3.MoveTowards (
					shots [i].transform.localPosition, 
					new Vector3 (shotX, shotY, 0),
					20);
				
				
				shots [i].GetComponent<Cat> ().die = true;
				
				if (shots [i].transform.localPosition == new Vector3 (shotX, shotY, 0)) {
					putShots++;
					//Debug.Log(putBombs);
					//newBomb = true;
				}
				
				if (putShots == 3) {
					recal = false;
					NewShot ();
					newShot = false;
					shotCabin1 = false;
					shotCabin2 = false;
					shotCabin3 = false;
					shotCabin4 = false;
					noShotCabin1 = false;
					noShotCabin2 = false;
					noShotCabin3 = false;
					noShotCabin4 = false;
					//numOfShot--;
					putShots = 0;
					
					
					
				}
				
				
				//else {newBomb = false;}
				
				//newBomb = false;
				
				
				
			}
			
			
			
			
			
			
			
			
			
			
		}



	}

	void HealMerge ()
	{

		if (newHealGo != null) {
			//Debug.Log("New Bomb");
			
			/*if (newHealGo.GetComponent<Cat> ().die) {
				if (!numOfHealToZero) {
					numOfHeal--;
					numOfHealToZero = true;
				}
			}*/
		}
		
		if (healLevel > 10) {
			healLevel = 10;		
		}
		
		
		List<GameObject> heals = new List<GameObject> ();
		for (int j = 0; j < go.Length; j++) {
			if (go [j].GetComponent<Cat> ().catsType == Cat.CatsType.Heal) {
				if (go [j].GetComponent<Cat> ().Shoot == true) {
					heals.Add (go [j]);
					
				}
				
				
			}
		}
		
		if (Cabin.healPut == 0) {
			//heals.Clear();
			healX = 0;
			healY = 0;
		}
		for (int j = 0; j < heals.Count; j++) {
			//Debug.Log("Heal 3");
			/*if (heals [j].transform.localPosition.y < healY) {
				healY = heals [j].transform.localPosition.y;
			}*/
			//Debug.Log(bombs[i].transform.localPosition.y);

			healY = heals[heals.Count - 1].transform.localPosition.y;
			healX = heals[heals.Count - 1].transform.localPosition.x;
			
			if (numOfHeal == 3) {
				
				
				recal = true;
				/*if (healLevel < 2) {
					numOfHeal = 0;
				} else {
					numOfHeal = 1;
				}*/
				//bombs.RemoveAt(i);
				//numOfBomb = 0;
				
				Cat.levelUp = true;
				healLevel = heals [j].GetComponent<Cat> ().Level;
				healLevel++;
				//Debug.Log(bombLevel);
				newHeal = true;
				//bombs.RemoveAt(i);
				//bombs.Clear();
				
			}
			
			if (newHeal) {
				if (heals [j].GetComponent<Cat> ().putPosition == Defines.cabin1) {
					if (!noHealCabin1) {
						Debug.Log("Heal Combination");
						cabin1cats.Remove(heals[j].gameObject);
						Cat.catsOutOfCabin1--;
						noHealCabin1 = true;
					}
				}
				if (heals [j].GetComponent<Cat> ().putPosition == Defines.cabin2) {
					if (!noHealCabin2) {
						Cat.catsOutOfCabin2--;
						cabin2cats.Remove(heals[j].gameObject);
						noHealCabin2 = true;
					}
				}
				if (heals [j].GetComponent<Cat> ().putPosition == Defines.cabin3) {
					if (!noHealCabin3) {
						Cat.catsOutOfCabin3--;
						cabin3cats.Remove(heals[j].gameObject);
						noHealCabin3 = true;
					}
				}
				if (heals [j].GetComponent<Cat> ().putPosition == Defines.cabin4) {
					if (!noHealCabin4) {
						Cat.catsOutOfCabin4--;
						cabin4cats.Remove(heals[j].gameObject);
						noHealCabin4 = true;
					}
				}
				
				if (healY == Defines.cabin4.y && healX == Defines.cabin4.x) {
					if (!healCabin4) {
						if (healLevel < 3) {
							Cat.catsOutOfCabin4 += 1;
						} else {
							Cat.catsOutOfCabin4 += 2;
							
						}
						healCabin4 = true;
						
					}
					
					
				}
				if (healY == Defines.cabin1.y  && healX == Defines.cabin1.x) {
					if (!healCabin1) {
						if (healLevel < 3) {
							Cat.catsOutOfCabin1 += 1;
						} else {
							Cat.catsOutOfCabin1 += 2;
							
						}
						healCabin1 = true;
					}
				}
				if (healY == Defines.cabin2.y  && healX == Defines.cabin2.x) {
					if (!healCabin2) {
						if (healLevel < 3) {
							Cat.catsOutOfCabin2 += 1;
						} else {
							Cat.catsOutOfCabin2 += 2;
							
						}
						healCabin2 = true;
					}
				}
				if (healY == Defines.cabin3.y  && healX == Defines.cabin3.x) {
					if (!healCabin3) {
						if (healLevel < 3) {
							Cat.catsOutOfCabin3 += 1;
						} else {
							Cat.catsOutOfCabin3 += 2;
							
						}
						healCabin3 = true;
					}
				}
				
				heals [j].transform.localPosition = Vector3.MoveTowards (
					heals [j].transform.localPosition, 
					new Vector3 (healX, healY, 0),
					20);
				
				heals [j].GetComponent<Health>().health = -1;
				heals [j].GetComponent<Cat> ().die = true;
				
				if (heals [j].transform.localPosition == new Vector3 (healX, healY, 0)) {
					putHeals++;
					//Debug.Log(putBombs);
					//newBomb = true;
				}
				
				if (putHeals == 3) {


					recal = false;
					NewHeal ();
					newHeal = false;
					healCabin1 = false;
					healCabin2 = false;
					healCabin3 = false;
					healCabin4 = false;
					noHealCabin1 = false;
					noHealCabin2 = false;
					noHealCabin3 = false;
					noHealCabin4 = false;
					//numOfHeal--;
					putHeals = 0;
					
					
					
				}
				
				
			}
			
		}
	}


	public void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
		isP1Available = true;
		isP2Available = true;
		isP3Available = true;
		bombLevel = 1;
		healLevel = 1;
		shotLevel = 1;
		numOfBomb = 0;
		numOfShot = 0;
		numOfHeal = 0;
		cabin1cats = new List<GameObject> ();
		cabin2cats = new List<GameObject> ();
		cabin3cats = new List<GameObject> ();
		cabin4cats = new List<GameObject> ();
		maxDistance = 0;
	}


	IEnumerator DisCal ()
	{
		yield return new WaitForSeconds (0.1f);
		maxDistance++;
		StartCoroutine("DisCal");
		//CancelInvoke ();
	}
	
	
}
