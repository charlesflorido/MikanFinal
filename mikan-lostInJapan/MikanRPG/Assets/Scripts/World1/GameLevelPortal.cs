using UnityEngine;
using System.Collections;

public class GameLevelPortal : MonoBehaviour {

    public int level;


    void OnTriggerEnter2D(Collider2D player)
    {
        if(level >= 0)
        {

            Application.LoadLevel(level);
        }
    }

}
