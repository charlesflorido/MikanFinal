using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ScoreBoardButtons : MonoBehaviour, IPointerClickHandler {

    public ErrorPanePortal pane;
    public bool isSavable;
    public int level;

    public void OnPointerClick(PointerEventData eventData)
    {
        SaveLoad.Save();
        if(isSavable)
        {

            pane.Open(level);
        }
        else
        {
            Application.LoadLevel(level);
        }
    }

    // Use this for initialization
    void Start () {
	    
	}



}
