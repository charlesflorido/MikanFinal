using UnityEngine;
using System.Collections;

[System.Serializable]
public class Profile{

	public string profileName;
	public int money;
    public int exp;
	public float musicVol;
	public float effectsVol;

    public bool islastSelected;

	public Profile(){

		profileName = "";
		money = 100;
		exp = 100;
		musicVol = 5.0f;
		effectsVol = 5.0f;
        islastSelected = false;

	}
}
