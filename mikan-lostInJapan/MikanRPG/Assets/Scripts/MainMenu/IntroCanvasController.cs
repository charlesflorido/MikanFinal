using UnityEngine;
using System.Collections;
using System;
public class IntroCanvasController : MonoBehaviour {

    public static IntroCanvasController instance;


    private Animator anim;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

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

    public void open(bool isOpen)
    {
        try {
            anim.SetBool("open", isOpen);
        }
        catch(NullReferenceException ex)
        {
            GetComponent<Animator>().SetBool("open", isOpen);
        }
    }

}
