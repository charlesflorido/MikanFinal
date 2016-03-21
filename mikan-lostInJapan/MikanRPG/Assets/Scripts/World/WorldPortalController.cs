using UnityEngine;

public class WorldPortalController : MonoBehaviour, Portal
{

    public ShipController ship;
    
    public void OnTriggerEnter2D(Collider2D player)
    {
        ship.GoToWorld2();
    }

    public void OnTriggerExit2D(Collider2D player)
    {
        
    }
}
