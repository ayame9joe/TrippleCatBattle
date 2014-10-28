using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
	private bool underControl = true;

	private bool pointerUp = true;
	public float cabin1distance;
	public float cabin2distance;
	public float cabin3distance;
	public float cabin4distance;

	public float minDis;
	float minDis1;
	float minDis2;

	public bool UnderControl
	{
		get
		{
			//Some other code
			return underControl;
		}
		set
		{
			//Some other code
			underControl = value;
		}
	}

	public bool PointerUp
	{
		get
		{
			//Some other code
			return pointerUp;
		}
		set
		{
			//Some other code
			pointerUp = value;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (underControl)
		{
			this.gameObject.transform.position = Input.mousePosition;
			cabin1distance = Vector3.Distance (this.transform.position, GameObject.Find("Cabin1").transform.position);
			cabin2distance = Vector3.Distance (this.transform.position, GameObject.Find("Cabin2").transform.position);
			cabin3distance = Vector3.Distance (this.transform.position, GameObject.Find("Cabin3").transform.position);
			cabin4distance = Vector3.Distance (this.transform.position, GameObject.Find("Cabin4").transform.position);

			minDis1 = Mathf.Min (cabin1distance, cabin2distance);
			minDis2 = Mathf.Min (cabin3distance, cabin4distance);

			minDis = Mathf.Min(minDis1, minDis2);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//缩小
		transform.localScale=new Vector3(0.7f,0.7f,0.7f);

		pointerUp = false;
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		//正常大小
		transform.localScale=new Vector3(1f,1f,1f);

		underControl = false;

		pointerUp = true;
		if (minDis > 50) {
			Destroy(this.gameObject);
		}

		//if (this.underControl) {

			
		//}
	}
}
