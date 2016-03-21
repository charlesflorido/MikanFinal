using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class restorOk : MonoBehaviour {


    public Text text;
    public int level;


    private int decoy;

    public void clickThis()
    {
        if(int.TryParse(text.text, out decoy))
        {
            
            int n = int.Parse(text.text);
            PlayGlobalVariables.addMoney(n);
            Application.LoadLevel(level);
        }
    }
}
