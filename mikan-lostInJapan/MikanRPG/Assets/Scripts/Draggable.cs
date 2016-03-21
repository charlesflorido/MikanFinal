using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (gameObject.name + ": " + transform.position.x + " -- " + transform.position.y);
	}

	public void OnBeginDrag(PointerEventData eventData){

	}

	public void OnDrag(PointerEventData eventData){
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		point.z = gameObject.transform.position.z;
		transform.position = point;
		//transform.Translate (eventData.position);
	}

	public void OnEndDrag(PointerEventData eventData){
	
	}

}
