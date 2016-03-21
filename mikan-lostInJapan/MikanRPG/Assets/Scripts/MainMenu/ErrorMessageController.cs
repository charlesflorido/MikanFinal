using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorMessageController : MonoBehaviour
{
    public static ErrorMessageController instance;

    public Text errorMessage;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        errorMessage.text = "No message";
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;;
        }
        else {
            Destroy(this);
        }

    }


    public void setMessage(string msg)
    {
        errorMessage.text = msg;
    }

    public void open(bool isOpen)
    {
        anim.SetBool("open", isOpen);
    }

}

