using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour {


	public enum CatsType{Shot, Bomb, Heal};

	public CatsType catsType;

	public bool die;
	private bool shoot;

	bool onceBorn = false;
	bool onceDie = false;

	private int level = 1;

	public Text txtLevel;

	public bool catsRandom = true;

	public static bool levelUp = false;

	public static int catsOutOfCabin1;
	public static int catsOutOfCabin2;
	public static int catsOutOfCabin3;
	public static int catsOutOfCabin4;

	public float waitForDestroy = 0.25f;



	bool onceCabin1;
	bool onceOutCabin1 = false;
	bool NoDieCabin1;
	bool onceCabin2;
	bool onceOutCabin2 = false;
	bool NoDieCabin2;
	bool onceCabin3;
	bool onceOutCabin3 = false;
	bool NoDieCabin3;
	bool onceCabin4;
	bool onceOutCabin4 = false;
	bool NoDieCabin4;


	public Vector3 putPosition; 

	public bool moveToCabin1;
	public bool moveToCabin2;
	public bool moveToCabin3;
	public bool moveToCabin4;


	public bool Shoot
	{
		get
		{
			//Some other code
			return shoot;
		}
		set
		{
			//Some other code
			shoot = value;
		}
	}


	public int Level
	{
		get
		{
			//Some other code
			return level;
		}
		set
		{
			//Some other code
			level = value;
		}
	}


	
	// Use this for initialization
	void Start () {

		if (catsRandom)
		{
			CatsRandom ();
		}

		TypeOfCats ();

	
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (this.putPosition);


		
		if (this.shoot) {this.GetComponent<DraggableObject> ().minDis = 0;

				
		}

	//	Debug.Log (putPosition);

		if (this.putPosition + new Vector3(-300, 0, 0) == Defines.cabin1) {

			if (this.transform.localPosition != Defines.cabin1)
			{
				//Debug.Log("^^^^");
				GameManager.cabin1cats.Remove(this.gameObject);
			}
		}
		if (this.putPosition + new Vector3(-300, 0, 0) == Defines.cabin2) {
			
			if (this.transform.localPosition != Defines.cabin2)
			{
				//Debug.Log("^^^^");
				GameManager.cabin2cats.Remove(this.gameObject);
			}
		}
		if (this.putPosition + new Vector3(-300, 0, 0) == Defines.cabin3) {
			
			if (this.transform.localPosition != Defines.cabin3)
			{
				//Debug.Log("^^^^");
				GameManager.cabin3cats.Remove(this.gameObject);
			}
		}
		if (this.putPosition + new Vector3(-300, 0, 0) == Defines.cabin4) {
			
			if (this.transform.localPosition != Defines.cabin4)
			{
				//Debug.Log("^^^^");
				GameManager.cabin4cats.Remove(this.gameObject);
			}
		}


		//Debug.Log ("Cabin4:" + catsOutOfCabin4);
		//Debug.Log ("Cabin3:" + catsOutOfCabin3);
		//Debug.Log ("Cabin2:" + catsOutOfCabin2);
		//Debug.Log ("Cabin1:" + catsOutOfCabin1);

		if (!GameManager.recal)
		{
			if (this.GetComponent<DraggableObject> ().minDis != 0)
			{
				
				if (this.GetComponent<DraggableObject> ().minDis == this.GetComponent<DraggableObject> ().cabin1distance) {
					moveToCabin1 = true;	
				}
				else
				{
					moveToCabin1 = false;
				}
				if (this.GetComponent<DraggableObject> ().minDis == this.GetComponent<DraggableObject> ().cabin2distance) {
					moveToCabin2 = true;	
				}
				else
				{
					moveToCabin2 = false;
				}
				if (this.GetComponent<DraggableObject> ().minDis == this.GetComponent<DraggableObject> ().cabin3distance) {
					moveToCabin3 = true;	
				}
				else
				{
					moveToCabin3 = false;
				}
				if (this.GetComponent<DraggableObject> ().minDis == this.GetComponent<DraggableObject> ().cabin4distance) {
					moveToCabin4 = true;	
				}
				else
				{
					moveToCabin4 = false;
				}
				
			}	
				if (!this.GetComponent<DraggableObject>().UnderControl)
				{
					if (moveToCabin1) {
						
						Debug.Log ("Yes");
						this.GetComponent<Cat>().Shoot = true;
						this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Cabin1").transform.position, 50f);
						
						if (this.transform.position == GameObject.Find("Cabin1").transform.position)
						{
							moveToCabin1 = false;
							GameManager.cabin1cats.Add(this.gameObject);
						if (this.die)
						{
							GameManager.cabin1cats.Remove(this.gameObject);
						}
					}


				}
				if (moveToCabin2) {
						
						this.GetComponent<Cat>().Shoot = true;
						this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Cabin2").transform.position, 50f);
						
						if (this.transform.position == GameObject.Find("Cabin2").transform.position)
						{
							moveToCabin2 = false;
						GameManager.cabin2cats.Add(this.gameObject);
						if (this.die)
						{
							GameManager.cabin2cats.Remove(this.gameObject);
						}
					}
					}
					if (moveToCabin3) {
						
						this.GetComponent<Cat>().Shoot = true;
						this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Cabin3").transform.position, 50f);
						
						if (this.transform.position == GameObject.Find("Cabin3").transform.position)
						{
							moveToCabin3 = false;
						GameManager.cabin3cats.Add(this.gameObject);
						if (this.die)
						{
							GameManager.cabin3cats.Remove(this.gameObject);
						}
					}
					}
					if (moveToCabin4) {
						
						this.GetComponent<Cat>().Shoot = true;
						this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Cabin4").transform.position, 50f);
						
						if (this.transform.position == GameObject.Find("Cabin4").transform.position)
						{
							moveToCabin4 = false;
						GameManager.cabin4cats.Add(this.gameObject);
						if (this.die)
						{
							GameManager.cabin4cats.Remove(this.gameObject);
						}
					}
					}
					//Debug.Log (this.GetComponent<DraggableObject> ().minDis);
				}

			
			if (!onceCabin4) {
				if (this.transform.localPosition != Defines.cabin4)
				{
					catsOutOfCabin4++;
				}
				onceCabin4 = true;
			}

			if (this.transform.localPosition == Defines.cabin4)
			{
				if (!onceOutCabin4)
				{
					catsOutOfCabin4--;
					onceOutCabin4 = true;
					NoDieCabin4 = true;
				}
			}



			if (!onceCabin3) {
				if (this.transform.localPosition != Defines.cabin3)
				{
					catsOutOfCabin3++;
				}
				onceCabin3 = true;
			}
			
			if (this.transform.localPosition == Defines.cabin3)
			{
				if (!onceOutCabin3)
				{
					catsOutOfCabin3--;
					onceOutCabin3 = true;
					NoDieCabin3 = true;
				}
			}

			if (!onceCabin2) {
				if (this.transform.localPosition != Defines.cabin2)
				{
					catsOutOfCabin2++;
				}
				onceCabin2 = true;
			}
			
			if (this.transform.localPosition == Defines.cabin2)
			{
				if (!onceOutCabin2)
				{
					catsOutOfCabin2--;
					onceOutCabin2 = true;
					NoDieCabin2 = true;
				}
			}

			if (!onceCabin1) {
				if (this.transform.localPosition != Defines.cabin1)
				{
					catsOutOfCabin1++;
				}
				onceCabin1 = true;
			}
			
			if (this.transform.localPosition == Defines.cabin1)
			{
				if (!onceOutCabin1)
				{
					catsOutOfCabin1--;
					onceOutCabin1 = true;
					NoDieCabin1 = true;
				}
			}
		}

		txtLevel.text = "lv " + level;

		if (catsType == CatsType.Heal) {

			if (shoot)
			{
				if (GameObject.Find("Ship").GetComponent<Health>().health < 98f)
					InvokeRepeating("Healing", 1, 1);

				if (!onceBorn)
				{
					Cabin.healPut++;
					GameManager.numOfHeal++;
					onceBorn = true;
				}
			}

		}
		else if (catsType == CatsType.Shot)
		{
			if (shoot)
			{

				WeaponScript weapon = GetComponent<WeaponScript>();
				if (weapon != null)
				{
					// false because the player is not an enemy
					weapon.Attack(false);

				}
				if (!onceBorn)
				{
					Cabin.shotPut++;
					GameManager.numOfShot++;
					onceBorn = true;
				}

			}

		}
		else if (catsType == CatsType.Bomb)
		{
			if (shoot)
			{
				WeaponScript weapon = GetComponent<WeaponScript>();
				weapon.IsShot = false;
				if (weapon != null)
				{
					// false because the player is not an enemy
					weapon.Attack(false);
				}
				if (!onceBorn)
				{
					Cabin.bombPut++;
					GameManager.numOfBomb++;
					onceBorn = true;
				}


			}

		}



		if (shoot) {

					
		}

		if (die) {
			StartCoroutine(DestroyCat());


			if (!onceDie)
			{
				if (!NoDieCabin4)
				{
					catsOutOfCabin4--;
				}
				if (!NoDieCabin3)
				{
					catsOutOfCabin3--;
				}
				if (!NoDieCabin2)
				{
					catsOutOfCabin2--;
				}
				if (!NoDieCabin1)
				{
					catsOutOfCabin1--;
				}

				if (this.catsType == CatsType.Shot)
				{
					GameManager.numOfShot--;
				}
				if (this.catsType == CatsType.Bomb)
				{
					GameManager.numOfBomb--;
				}
				if (this.catsType == CatsType.Heal)
				{
					GameManager.numOfHeal--;
				}


				onceDie = true;
			}

		}


		switch (catsType) {
			
		case CatsType.Shot:
			//this.GetComponent<Image>().color = Color.red;
			level = GameManager.shotLevel;
			break;
		case CatsType.Bomb:
			//this.GetComponent<Image>().color = Color.yellow;
			level = GameManager.bombLevel;
			break;
		case CatsType.Heal:
			level = GameManager.healLevel;
			//this.GetComponent<Image>().color = Color.green;
			break;
		}
		
	}

	void CatsRandom ()
	{
		catsType = (CatsType)Random.Range (0, 3);

		//catsType = CatsType.Heal;

	
		

	}

	IEnumerator DestroyCat ()
	{


		yield return new WaitForSeconds (waitForDestroy);
		if (onceDie)
		{
			if (this.catsType == CatsType.Bomb)
			{
				Cabin.bombPut--;
			}
			if (this.catsType == CatsType.Heal)
			{
				Cabin.healPut--;
			}
			if (this.catsType == CatsType.Shot)
			{
				Cabin.shotPut--;


			}
			onceDie = false;
		}
		Destroy (this.gameObject);
	}


	void TypeOfCats ()
	{
		switch (catsType) {
			
		case CatsType.Shot:
			this.GetComponent<Image>().color = Color.red;

			break;
		case CatsType.Bomb:
			this.GetComponent<Image>().color = Color.yellow;
			//level = GameManager.bombLevel;
			break;
		case CatsType.Heal:
			this.GetComponent<Image>().color = Color.green;
			break;
		}
	}



	void Healing ()
	{
		if (GameObject.Find("Ship").GetComponent<Health>().health < 98f)
		{
			if (this.level == 1)
			GameObject.Find("Ship").GetComponent<Health>().health += 2f;
			if (this.level == 2)
				GameObject.Find("Ship").GetComponent<Health>().health += 4f;
			if (this.level == 3)
				GameObject.Find("Ship").GetComponent<Health>().health += 6f;
			if (this.level == 4)
				GameObject.Find("Ship").GetComponent<Health>().health += 8f;
			if (this.level == 5)
				GameObject.Find("Ship").GetComponent<Health>().health += 10f;
			if (this.level == 6)
				GameObject.Find("Ship").GetComponent<Health>().health += 12f;
			if (this.level == 7)
				GameObject.Find("Ship").GetComponent<Health>().health += 14f;
			if (this.level == 8)
				GameObject.Find("Ship").GetComponent<Health>().health += 16f;
			if (this.level == 9)
				GameObject.Find("Ship").GetComponent<Health>().health += 18f;
			if (this.level == 10)
				GameObject.Find("Ship").GetComponent<Health>().health += 20f;
		}
		CancelInvoke ();
	}

}
