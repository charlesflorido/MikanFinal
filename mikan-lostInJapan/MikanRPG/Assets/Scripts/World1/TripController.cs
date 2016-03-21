using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TripController : MonoBehaviour {

    
    public ShipController ship;
    public Text text;
    public bool level1 = true;

    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    public void Open()
    {
        anim.SetBool("open", true);
        text.text = "Pay \n¥7,000";

        if (level1 && PlayGlobalVariables.experience >= 7000)
        {
            if((PlayGlobalVariables.money - PlayGlobalVariables.experience) < 0)
            {
                text.text = "Free";
            }
        }
        else if (PlayGlobalVariables.experience >= 14000)
        {
            if (((PlayGlobalVariables.money + 7000) - PlayGlobalVariables.experience) < 0)
            {
                text.text = "Free";
            }
        }

    }

    public void Close()
    {
        Debug.Log("Closing");
        anim.SetBool("open", false);

    }

    public void Pay()
    {
        
        if(PlayGlobalVariables.experience >= 7000){
            if((PlayGlobalVariables.money - PlayGlobalVariables.experience) < 0)
            {
                ship.GoToWorld1();
                Close();
            }
            else
            {
                PlayGlobalVariables.reduceMoney(7000);
                ship.GoToWorld1();
                Close();
            }
        }
        else if (PlayGlobalVariables.money >= 7000)
        {
            PlayGlobalVariables.reduceMoney(7000);
            ship.GoToWorld1();
            Close();
        }
        else
        {
            text.text = "You don't have enough money ";
        }
    }

    public void Pay2()
    {
        if(PlayGlobalVariables.experience >= 14000)
        {
            if (((PlayGlobalVariables.money + 7000) - PlayGlobalVariables.experience) < 0)
            {
                Application.LoadLevel(20);
            }
            else
            {
                PlayGlobalVariables.reduceMoney(7000);
                Application.LoadLevel(20);
            }
        }
        if (PlayGlobalVariables.money >= 7000)
        {
            PlayGlobalVariables.reduceMoney(7000);
            Application.LoadLevel(21);
        }
        else
        {
            text.text = "You don't have enough money ";
        }
    }

    
}
