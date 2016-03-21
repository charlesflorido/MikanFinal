using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
	
		if (other.gameObject.name == "Card") {
			Debug.Log (name + " collides with card.");
		}
	}
}
