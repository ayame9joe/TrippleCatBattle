using UnityEngine;
using System.Collections;

public class CatHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log()
	}

	void OnTriggerStay2D (Collider2D other)
	{
		switch (this.name)
		{
		case "P1":

			if (other.tag == "Cat")
			{
				GameManager.isP1Available = false;
			}
			break;
		case "P2":

			if (other.tag == "Cat")
			{
				GameManager.isP2Available = false;
			}
			break;
		case "P3":

			if (other.tag == "Cat")
			{
				GameManager.isP3Available = false;
			}

			break;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		switch (this.name)
		{
		case "P1":
			
			if (other.tag == "Cat")
			{
				GameManager.isP1Available = true;
			}
			break;
		case "P2":
			
			if (other.tag == "Cat")
			{
				GameManager.isP2Available = true;
			}
			break;
		case "P3":
			
			if (other.tag == "Cat")
			{
				GameManager.isP3Available = true;
			}
			
			break;
		}
	}
}
