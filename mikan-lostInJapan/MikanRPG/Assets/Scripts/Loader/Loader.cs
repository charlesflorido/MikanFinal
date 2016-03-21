using UnityEngine;
using System.Collections;

/*
This class is used for Loading Scenes.
*/
public class Loader : MonoBehaviour {

    public int level; //The scene to loaded after 2 seconds
	
    /* Begins couroutine */
	void Start () {
        StartCoroutine(SceneLoad());
	}
	

    /* Loads the scene after 3 seconds */
	private IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(level);
    }
}
