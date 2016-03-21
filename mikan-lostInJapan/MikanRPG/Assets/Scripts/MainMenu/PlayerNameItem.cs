using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerNameItem : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

    public Button btnDelete;
    public Text textName;
    public bool isSelect;

    private Animator anim;



    public void OnPointerEnter(PointerEventData eventData)
    {
        btnDelete.gameObject.active = true;
        anim.SetBool("hover",true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnDelete.gameObject.active = false;
        anim.SetBool("hover", false);
    }

    public void selected(bool isSelected)
    {
        GetComponent<Animator>().SetBool("click", isSelected);
    }

    // Use this for initialization
    void Start () {
        btnDelete.gameObject.active = false;
        anim = GetComponent<Animator>();
        anim.SetBool("click", isSelect);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public string getName()
    {
        return textName.text;
    }

    public void setName(string playerName)
    {
        textName.text = playerName;
    }
}
