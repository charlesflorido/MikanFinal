using UnityEngine;
using System.Collections;

public class TripControllerGeneral : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Close()
    {
        anim.SetBool("open", false);

    }

 
}
