using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cabin : MonoBehaviour {


	bool catPut = false;

	//int numOfCatPut;

	bool oncePut;
	bool onceOut;

	public static int bombPut;
	public static int healPut;
	public static int shotPut;

	bool cabin1put;

	GameObject[] go;

	bool bombLevelToZero;
	bool healLevelToZero;
	bool shotLevelToZero;
	List<Collider2D> others = new List<Collider2D> ();
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (cabin1put);

		go = GameObject.FindGameObjectsWithTag("Cat");
		//Debug.Log(go.Length);
		if (GameManager.bombLevel > 1) {

			bombLevelToZero = false;

			if (bombPut == 0)
			{
				//Debug.Log("Level to Zero");

				if (!bombLevelToZero)
				{
					GameManager.bombLevel = 1;

					bombLevelToZero = true;
				}
			}
		}
		if (GameManager.healLevel > 1) {
			
			healLevelToZero = false;
			
			if (healPut == 0)
			{
				//Debug.Log("Level to Zero");
				
				if (!healLevelToZero)
				{
					GameManager.healLevel = 1;
					
					healLevelToZero = true;
				}
			}
		}
		if (GameManager.shotLevel > 1) {
			
			shotLevelToZero = false;
			
			if (shotPut == 0)
			{
				//Debug.Log("Level to Zero");
				
				if (!shotLevelToZero)
				{
					GameManager.shotLevel = 1;
					
					shotLevelToZero = true;
				}
			}
		}



	}

	void OnTriggerStay2D (Collider2D other)
	{

		if (other.tag == "Cat") {


			others.Add (other);
			if (other.GetComponent<Cat>().die)
			{
				others.Remove(other);
			}


			if (other.GetComponent<Cat>().Shoot)
			{
				other.GetComponent<Cat>().putPosition = this.transform.localPosition;
			}

			/*if (this.name == "Cabin1")
			{
				if (other.GetComponent<Cat>().moveToCabin1)
				{
					Debug.Log("Yehal");

					//other.GetComponent<DraggableObject>().UnderControl = false;
					other.GetComponent<Cat>().Shoot = true;
					other.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position, 50f);
				}
			}
			if (this.name == "Cabin2")
			{
				if (other.GetComponent<Cat>().moveToCabin2)
				{
				//	other.GetComponent<DraggableObject>().UnderControl = false;
					other.GetComponent<Cat>().Shoot = true;
					other.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position, 50f);
				}
			}
			if (this.name == "Cabin3")
			{
				if (other.GetComponent<Cat>().moveToCabin3)
				{
				//other.GetComponent<DraggableObject>().UnderControl = false;
					other.GetComponent<Cat>().Shoot = true;
					other.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position, 50f);
				}
			}
			if (this.name == "Cabin4")
			{
				if (other.GetComponent<Cat>().moveToCabin4)
				{
					//other.GetComponent<DraggableObject>().UnderControl = false;
					other.GetComponent<Cat>().Shoot = true;
					other.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position, 50f);
				}
			}*/
		}

	}





}
