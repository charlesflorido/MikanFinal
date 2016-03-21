using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class IntroTitleController : MonoBehaviour{


    public float time;

    private float originalTime;
    
    // Use this for initialization
    void Start () {
        originalTime = time;
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
        }
	    
        if(time < 0)
        {
            Application.LoadLevel(1);
        }
        else
        {
            time -= Time.deltaTime;
        }

	}
    



}
