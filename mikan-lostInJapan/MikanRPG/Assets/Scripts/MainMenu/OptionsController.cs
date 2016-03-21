using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {


    public static float volMusic = 0.0f;
    public static float volEffects = 0.0f;

    public Slider slideMusic;
    public Slider slideEffects;

    private Animator anim;


	void Start () {
        anim = GetComponent<Animator>();
    }
	
	public void Open (bool isOpen) {
        anim.SetBool("open", isOpen);
	}


    public void UpdateVolume()
    {
        volMusic = Game.current.currentProfile.musicVol;
        volEffects = Game.current.currentProfile.effectsVol;

        slideMusic.value = volMusic;
        slideEffects.value = volEffects;
    }

    public void UpdateMusic()
    {
        volMusic = slideMusic.value;
        Game.current.currentProfile.musicVol = volMusic;
        SaveLoad.Save();
    }

    public void UpdateEffects()
    {
        volEffects = slideEffects.value;
        Game.current.currentProfile.effectsVol = volEffects;
        SaveLoad.Save();
    }
}
