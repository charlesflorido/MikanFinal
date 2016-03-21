using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreErrorController : MonoBehaviour {

    public static StoreErrorController instance;

    public Text text;
    private Animator anim;
    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	    
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

    public void setMoney(int n)
    {
        text.text = "" + n;
    }

    public void Open(bool isOpen)
    {
        anim.SetBool("open", isOpen);
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel(3);
    }

   


}
