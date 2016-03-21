using UnityEngine;
using System.Collections;
using System;

public class ShipPortal : MonoBehaviour {

    public TripController tripPanel;

    void OnTriggerEnter2D(Collider2D player)
    {
        tripPanel.Open();
    }


    void OnTriggerExit2D(Collider2D player)
    {
        tripPanel.Close();
    }


    
}
