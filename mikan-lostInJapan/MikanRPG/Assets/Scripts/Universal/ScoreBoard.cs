using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ScoreBoard : MonoBehaviour
{


    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerClick()
    {
        anim.SetBool("open", true);
        RestaurantGlobals.stop = true;
    }

    public void OnPointerEnter()
    {

        anim.SetBool("hover", true);
    }

    public void OnPointerExit()
    {
        anim.SetBool("hover", false);
    }

    public void Open(bool isOpen)
    {
        anim.SetBool("open", isOpen);
        RestaurantGlobals.stop = false;
    }
}
