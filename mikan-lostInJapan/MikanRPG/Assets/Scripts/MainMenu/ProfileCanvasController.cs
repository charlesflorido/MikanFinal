using UnityEngine;
using System.Collections;

public class ProfileCanvasController : MonoBehaviour
{

    private Animator anim;
   

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenCanvas(bool isOpen)
    {
        if(isOpen == false)
        {
            if(Game.current != null)
            {
                anim.SetBool("open", isOpen);
                MainMenu.instance.Open(true);
            }
            else
            {
                ErrorMessageController.instance.setMessage("Please select a player");
                ErrorMessageController.instance.open(true);
            }
        }
        else
        {
            MainMenu.instance.Open(false);
            anim.SetBool("open", isOpen);
        }

    }

}
