using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Animals : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;
	public Transform parentBefore = null;

	public enum AnimalType
	{
		DOG, CAT, PIG, MONKEY, PANDA, ZEBRA, GIRAFFE, HIPPO, LION, TIGER, FROG, SHEEP
	}

	public AnimalType type = AnimalType.DOG;

	public void OnBeginDrag(PointerEventData eventData){

		parentToReturnTo = this.transform.parent;
		parentBefore = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData){

		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){

		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

}