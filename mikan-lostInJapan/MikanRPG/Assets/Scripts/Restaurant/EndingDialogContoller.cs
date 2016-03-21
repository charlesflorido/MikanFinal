using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndingDialogContoller : MonoBehaviour {

	public static EndingDialogContoller instance;

	public Text mainText;
	public Text money;


	void Start(){
		RestaurantGlobals.Day = 1;
		RestaurantGlobals.score = 7;
		RestaurantGlobals.dragging = false;
		RestaurantGlobals.button = null;
		
		Debug.Log ("start");
	}


	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}

	}

	public void gameOver(int score){

        
		

        if (PlayGlobalVariables.hasEnoughExperience(2500) == false)
        {
            if (score <= 0)
            {
                mainText.text = "Game Over. Please practice more";
                score = 0;
            }
            else if (score <= 3)
            {
                mainText.text = "You could do better. Practice more";
            }
            else if (score <= 5)
            {
                mainText.text = "Not bad. A little practice can help";
            }
            else if (score == 6)
            {
                mainText.text = "Almost perfect. Great job";
            }
            else {
                mainText.text = "Perfect!";
            }

            int earned = score * 100;

            money.text = "" + earned;
            PlayGlobalVariables.addMoney(earned);
        }
        else
        {

            mainText.text = "You have enough experience.";
            money.text = "0";
        }

		stopGame ();

		GetComponent<Animator> ().SetBool ("active", true);



	}

	private void stopGame(){
		RestaurantGlobals.stop = true;
	}
}
