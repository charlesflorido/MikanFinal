using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
public class CheatBoxController : MonoBehaviour {

    public InputField inputCheat;
    public Text playerName;

    private Animator anim;

    public void Start()
    {
        try {
            playerName.text = Game.current.currentProfile.profileName;
        }catch(NullReferenceException ex)
        {

        }
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            open(!anim.GetBool("open"));
        }
    }

    public void open(bool isOpen)
    {
        anim.SetBool("open", isOpen);
    }

    public void EnterCheatCode()
    {
        string strCheat = inputCheat.text.ToLower();

        if (strCheat.Equals("money100"))
        {
            PlayGlobalVariables.addMoney(100);
        }
        else if (strCheat.Equals("money1000"))
        {
            PlayGlobalVariables.addMoney(1000);
        }
        else if (strCheat.Equals("money2000"))
        {
            PlayGlobalVariables.addMoney(2000);
        }
        else if (strCheat.Equals("debt100"))
        {
            PlayGlobalVariables.reduceMoney(100);
        }
        else if (strCheat.Equals("xdebt100"))
        {
            PlayGlobalVariables.reduceMoneyAndExperience(100);
        }

        inputCheat.text = "";
         
    }
}
