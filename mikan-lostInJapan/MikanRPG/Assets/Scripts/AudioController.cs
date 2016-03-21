using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    private AudioSource audio;
    public bool isMusic = true;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isMusic)
        {
            audio.volume = OptionsController.volMusic;
        }
        else
        {
            audio.volume = OptionsController.volEffects;
        }

	}
}
