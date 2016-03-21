using UnityEngine;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour {

    public static MainMenu instance;

    public Text profileName;

    private int profileNumber;
    private Animator anim;

	// Use this for initialization
	void Start () {
       

        anim = GetComponent<Animator>();
		Game.current = new Game ();
		Game.current.currentProfile.profileName = SaveLoad.list.latestGame;
        Debug.Log("latestGame: " + SaveLoad.list.latestGame);
		int cnt = -1;


		foreach(Game x in SaveLoad.list.savedGames)
		{
			if (x.currentProfile.profileName.Equals(Game.current.currentProfile.profileName))
			{
                cnt++;
                if (x.currentProfile.islastSelected)
                {
                    break;
                }
			}
		}

        if(cnt < 0)
        {
            cnt = 0;
        }

        profileName.text = "";
		profileNumber = cnt;
	}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }

    }


    public void Open(bool isOpen)
    {
        GetComponent<Animator>().SetBool("open", isOpen);
    }

    public void setProfileName(string profileName, int profileNum)
    {
        this.profileName.text = profileName;
        this.profileNumber = profileNum;
    }


    public int getProfileNumber()
    {
        return this.profileNumber;
    }

    public void exitGame()
    {
        Application.Quit();
    }
	

}
