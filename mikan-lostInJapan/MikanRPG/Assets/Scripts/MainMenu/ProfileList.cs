using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProfileList {

	public List<Game> savedGames = new List<Game>();
    public string latestGame;

	public ProfileList(){

	}

    public Game getProfile(string s)
    {
        Game profile = null;
        foreach(Game x in savedGames)
        {
            if (x.currentProfile.profileName.Equals(s))
            {
                profile = x;
                break;
            }
        }

        return profile;
    }

}
