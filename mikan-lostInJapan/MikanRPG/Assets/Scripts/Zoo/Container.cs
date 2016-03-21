using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems; 

public class Container : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	private Animals.AnimalType type;

	private Animals animal;

	public Image Callout;
	public Image checkOrNot;
	public Transform controller;
	string checkImage = "check";
	private string errorImage = "error";

	void Start(){

		Callout = Callout.GetComponent<Image> ();
		checkOrNot = checkOrNot.GetComponent<Image> ();
		controller = controller.GetComponent<Transform> ();
		checkOrNot.enabled = false;

		if (Callout != null)
			NewRequest ();

	}

	void Update(){
	}

	public void OnPointerEnter(PointerEventData eventData){
	}

	public void OnPointerExit(PointerEventData eventData){
	}

	public void OnDrop(PointerEventData eventData){

		animal = eventData.pointerDrag.GetComponent<Animals> ();

		if (animal != null) {

			animal.parentToReturnTo = this.transform;

			CheckAnswer(animal);

		}

	}

	private void CheckAnswer(Animals animal){

		if(type == animal.type){
			if(checkImage != ""){
				checkOrNot.sprite = Resources.Load<Sprite>("check");
				controller.GetComponent<ZooController>().money += 10;
				controller.GetComponent<ZooController>().earning.text = controller.GetComponent<ZooController>().money.ToString();
			}
		}else{
			if(errorImage != ""){
				checkOrNot.sprite = Resources.Load<Sprite>("error");
			}
		}
		checkOrNot.enabled = true;
		StartCoroutine (WaitForAFewSeconds());

	}

	private void NewRequest(){
		

		var values = Enum.GetValues (typeof(Animals.AnimalType));
		type = (Animals.AnimalType)values.GetValue(UnityEngine.Random.Range(0,values.Length));

		Callout.GetComponentInChildren<Text>().text = this.type.ToString();
		Callout.GetComponentInChildren<Text>().enabled = true;
		Callout.enabled = true;
		gameObject.GetComponentInChildren<RandomAnimal> ().animal.enabled = true;
		gameObject.GetComponentInChildren<RandomAnimal> ().LoadSprite ("animal faces");

	}

	IEnumerator WaitForAFewSeconds(){

		yield return new WaitForSeconds(UnityEngine.Random.Range(1,3));
		checkOrNot.enabled = false;
		Callout.GetComponentInChildren<Text>().enabled = false;
		Callout.enabled = false;
		gameObject.GetComponentInChildren<RandomAnimal> ().animal.enabled = false;
		gameObject.GetComponentInChildren<Animals> ().transform.SetParent (animal.parentBefore);
		yield return new WaitForSeconds(UnityEngine.Random.Range(3,6));
		NewRequest ();

	}
}
