using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float health = 100f;
	public Image healthUI;

	float difficultyIndex = 0.5f;
	// Use this for initialization
	void Start () {



	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health < 0) {

			if (this.tag == "Cat")
			{
				this.GetComponent<Cat>().die = true;
				if (this.transform.position == GameObject.Find("Cabin1").transform.position)
				{
				//Debug.Log("Delete this cat");
					GameManager.cabin1cats.Remove(this.gameObject);
				}
				if (this.transform.position == GameObject.Find("Cabin2").transform.position)
				{
					//Debug.Log("Delete this cat");
					GameManager.cabin2cats.Remove(this.gameObject);
				}
				if (this.transform.position == GameObject.Find("Cabin3").transform.position)
				{
					//Debug.Log("Delete this cat");
					GameManager.cabin3cats.Remove(this.gameObject);
				}
				if (this.transform.position == GameObject.Find("Cabin4").transform.position)
				{
					//Debug.Log("Delete this cat");
					GameManager.cabin4cats.Remove(this.gameObject);
				}
			}
			else {
				Destroy(this.gameObject);	
			}
		}

		healthUI.transform.localScale = new Vector3(this.health/100, 1, 1);

		InvokeRepeating ("CatHealth", 0, 1);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (this.tag == "Enemy")
		{
			if (other.tag == "Shot") {
				switch (GameManager.shotLevel)
				{
				case 1:
					this.health -= 3f * difficultyIndex;
					break;
				case 2:
					this.health -= 4f * difficultyIndex;
					break;
				case 3:
					this.health -= 5f * difficultyIndex;
					break;
				case 4:
					this.health -= 6f * difficultyIndex;
					break;
				case 5:
					this.health -= 7f * difficultyIndex;
					break;
				case 6:
					this.health -= 8f * difficultyIndex;
					break;
				case 7:
					this.health -= 9f * difficultyIndex;
					break;
				case 8:
					this.health -= 10f * difficultyIndex;
					break;
				case 9:
					this.health -= 11f * difficultyIndex;
					break;
				case 10:
					this.health -= 23f * difficultyIndex;
					break;
				}

			}
			if (other.tag == "Bomb")
			{
				switch (GameManager.bombLevel)
				{
				case 1:
					this.health -= 5f * difficultyIndex;
					break;
				case 2:
					this.health -= 7f * difficultyIndex;
					break;
				case 3:
					this.health -= 9f * difficultyIndex;
					break;
				case 4:
					this.health -= 11f * difficultyIndex;
					break;
				case 5:
					this.health -= 13f * difficultyIndex;
					break;
				case 6:
					this.health -= 15f * difficultyIndex;
					break;
				case 7:
					this.health -= 17f * difficultyIndex;
					break;
				case 8:
					this.health -= 19f * difficultyIndex;
					break;
				case 9:
					this.health -= 21f * difficultyIndex;
					break;
				case 10:
					this.health -= 23f * difficultyIndex;
					break;
				}

			}
		}
		if (other.tag == "Enemy") {
			this.health -= 5f;
			Destroy(other.gameObject);
		}
	}

	void CatHealth ()
	{
		if (this.tag == "Cat") {
			if (this.GetComponent<Cat>().Shoot == true)
			this.health -= 0.2f;

		}
		
		CancelInvoke ();
	}



}
