using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopEndController : MonoBehaviour {

	public static ShopEndController instance;
	
	public Text mainText;
	public Text money;
	public bool gameHasNumbers;
    public int requiredExp;
	
	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}
		
	}
	
	public void gameOver(int score){


        if (PlayGlobalVariables.hasEnoughExperience(requiredExp) == false)
        {
            if (score <= 0)
            {
                mainText.text = "Game Over. Please practice more";
                score = 0;
            }
            else if (score <= 2)
            {
                mainText.text = "You could do better. Practice more";
            }
            else if (score <= 3)
            {
                mainText.text = "Not bad. A little practice can help";
            }
            else if (score == 4)
            {
                mainText.text = "Almost perfect. Great job";
            }
            else {
                mainText.text = "Perfect!";
            }

            int earned = score * 200;

            money.text = "" + earned;
            PlayGlobalVariables.addMoney(earned);
        }
        else
        {
            mainText.text = "You have enough experience.";
            money.text = "0";
        }

        ShopGlobals.running = false;
		stopGame ();
		GetComponent<Animator> ().SetBool ("active", true);
		
	}
	
	private void stopGame(){
		ShopGlobals.running = false;
	}
}
