using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Game{
	
	public static Game current;
	public Profile currentProfile;

	public Game(){
		currentProfile = new Profile();
	}

}
 	