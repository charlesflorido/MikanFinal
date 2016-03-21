using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class GeneralLevelButton : MonoBehaviour, IPointerClickHandler {

    public int level;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.LoadLevel(level);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	
}
