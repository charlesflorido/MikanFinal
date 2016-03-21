using UnityEngine;
using System.Collections;

public class PortalGeneral : MonoBehaviour {

    public TripControllerGeneral tripPanel;

    void OnTriggerEnter2D(Collider2D player)
    {
        tripPanel.Open();
    }


    void OnTriggerExit2D(Collider2D player)
    {
        tripPanel.Close();
    }
}
