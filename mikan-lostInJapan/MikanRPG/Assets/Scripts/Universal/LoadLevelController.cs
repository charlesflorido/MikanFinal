using UnityEngine;
using System.Collections;
using System;

public class LoadLevelController : MonoBehaviour {

    public int level = 0;

    public void loadLevel()
    {

        try {
            Debug.Log("new money: " + Game.current.currentProfile.money);
            PlayGlobalVariables.money = Game.current.currentProfile.money;
            PlayGlobalVariables.experience = Game.current.currentProfile.exp;
            Application.LoadLevel(level);
        }catch(NullReferenceException ex)
        {
            ErrorMessageController.instance.setMessage("Error! Contact developer");
            ErrorMessageController.instance.open(true);
        }
    }
}
