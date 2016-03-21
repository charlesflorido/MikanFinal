using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class DeleteModalController : MonoBehaviour {

    public static DeleteModalController instance;
    public ProfileListController profileListController;
    public Text userText;

    private Animator anim;

    private int indxDelete = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Open(int indx)
    {
        anim.SetBool("open", true);
        try {
            userText.text = profileListController.listPlayer[indx].getName() + " ?";
            indxDelete = indx;
        }catch(Exception ex) 
        {

        }
       
    }


    public void DeleteProfile()
    {
        profileListController.deletePlayer(indxDelete);
        profileListController.updateSelectedPlayer();
        Close();
    }

    public void Close()
    {
        anim.SetBool("open", false);
    }
}
