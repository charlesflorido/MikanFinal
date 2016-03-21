using UnityEngine;
using System.Collections;

public class ErrorPanePortal : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    int level;
	void Start () {
        anim = GetComponent<Animator>();
        level = 0;
	}

    public void Open(int level)
    {
        this.level = level;
        anim.SetBool("open", true);
    }

    public void Close()
    {
        anim.SetBool("open", false);
    }

    public void onOkClick()
    {
        Application.LoadLevel(level);
    }
	

}
