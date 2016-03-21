using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZooController : MonoBehaviour {

	public Text profileName;
	public Text earning;
	public int money = 0;

	public Button playBtn;
	public Canvas playArea;
	public Canvas intro;
	public Canvas end;

	// Use this for initialization
	void Start () {
		SaveLoad.Load ();
		Game.current = new Game ();
		Debug.Log ("Active Profile: " + SaveLoad.list.latestGame);
		Game.current = SaveLoad.list.savedGames.Find (x => x.currentProfile.profileName == SaveLoad.list.latestGame);
		if (Game.current == null)
			Debug.Log ("No game found");

		intro = intro.GetComponent<Canvas> ();
		intro.enabled = true;

		playArea = playArea.GetComponent<Canvas> ();
		playArea.enabled = false;

		end = end.GetComponent<Canvas> ();
		end.enabled = false;

		earning = earning.GetComponent<Text> ();
		profileName = profileName.GetComponent<Text> ();
		earning.text = money.ToString ();
		profileName.text = Game.current.currentProfile.profileName;
	}

	// Update is called once per frame
	void Update () {

	}

	public void ClickPlay(){

		intro.enabled = false;
		end.enabled = false;
		playArea.enabled = true;
		StartCoroutine (startGameDelay());
		StopCoroutine (startGameDelay());

	}

	IEnumerator startGameDelay(){

		yield return new WaitForSeconds(2);
		playArea.GetComponent<ZooTimer> ().StartTimer();

	}
}
