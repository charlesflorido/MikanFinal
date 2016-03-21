using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class StoreButtonController : MonoBehaviour, IPointerClickHandler {

    public int requiredExp;
    public int level;

	// Use this for initialization
	void Start () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(PlayGlobalVariables.experience >= requiredExp)
        {
            Application.LoadLevel(level);
        }
        else
        {
            StoreErrorController.instance.setMoney(requiredExp);
            StoreErrorController.instance.Open(true);
        }
    }
}
