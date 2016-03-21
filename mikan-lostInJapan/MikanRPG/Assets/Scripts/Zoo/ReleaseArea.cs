using UnityEngine;

using System.Collections;
using UnityEngine.EventSystems; 

public class ReleaseArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){
	}

	public void OnPointerExit(PointerEventData eventData){
	}

	public void OnDrop(PointerEventData eventData){

		Animals animal = eventData.pointerDrag.GetComponent<Animals> ();

		if (animal != null) {

			animal.parentToReturnTo = this.transform;

		}

	}
}
