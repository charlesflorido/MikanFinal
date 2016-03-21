using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    public CameraController cameraController;
    public GameObject player;
    public int StartWorld = 0;


    private Animator anim;
       
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetInteger("world", StartWorld);
	}
	

	public void GoToWorld1()
    {
        dockPlayer();
        anim.SetInteger("world", 1);
    }

    public void GoToWorld2()
    {
        dockPlayer();
        anim.SetInteger("world", 2);
    }

    void dockPlayer()
    {
        cameraController.followTarget = this.gameObject;
        player.SetActive(false);
    }

    void unDockPlayer(int world)
    {
        if (StartWorld == 0)
        {
            player.SetActive(true);

            if (world == 1)
            {
                player.transform.position = new Vector3(-23.48f, 0.6f, player.transform.position.z);
            }
            else
            {
                player.transform.position = new Vector3(-38.71f, 0.6f, player.transform.position.z);
            }
        }
        else
        {
            StartWorld = 0;
        }

        cameraController.followTarget = player;
    }

   
}
