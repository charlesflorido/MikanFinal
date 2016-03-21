using UnityEngine;
using System.Collections;

public class AudioType : MonoBehaviour {

    public bool isMusic = true;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        if (isMusic)
        {
            audioSource.volume = PlayGlobalVariables.getMusicVolume();
        }
        else
        {
            audioSource.volume = PlayGlobalVariables.getEffectsVolume();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
