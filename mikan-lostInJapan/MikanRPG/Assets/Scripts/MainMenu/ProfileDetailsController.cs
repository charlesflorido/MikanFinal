using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ProfileDetailsController : MonoBehaviour {

    public static ProfileDetailsController instance;


    private Text profileName;
    // Use this for initialization
	void Start () {
        profileName = GetComponent<Text>();
        profileName.text = "";
	}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }

    }

    public void setName(string s)
    {
        try {
            profileName.text = s;
        }
        catch(NullReferenceException ex)
        {

        }
    }

    public void setInvalid()
    {
        //profileName.text = "Please select a player.";
    }
	
}
