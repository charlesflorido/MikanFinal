using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopLifeController : MonoBehaviour {


	public int score;
	private Text text; 

	// Use this for initialization
	void Start () {
		ShopGlobals.running = true;
		ShopGlobals.score = 5;

		text = GetComponent<Text> ();

		if (score < 0) {
			score = 1;
		}
		text.text = "" + score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reduceScore(){
		score--;

		ShopGlobals.score = score;
		text.text = "" + score;
		ShopSounds1.instance.playSound("fail");
		if (score == 0) {
			ShopEndController.instance.gameOver(0);
		}
	}

	public int getScore(){
		return score;
	}


}
