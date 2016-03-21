using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;

public class ProfileListController : MonoBehaviour {

    public PlayerNameItem[] listPlayer;
	public Text activeProfileName;
    public OptionsController optionsController;

    private int lastIndx;
    private int lastSelected = 0;




    void Start ()
    {

		activeProfileName = activeProfileName.GetComponent<Text> ();

		Game.current = null;
		lastIndx = -1;
       
        foreach(PlayerNameItem item in listPlayer)
        {
            item.gameObject.SetActive(false);
        }

        Game.current = new Game();
        Game.current.currentProfile.profileName = SaveLoad.list.latestGame;
        loadPlayers();
		
		activeProfileName.text = Game.current.currentProfile.profileName;
        Debug.Log("new name 555555: " + activeProfileName.text);
        //optionsController.UpdateVolume();

    }

   

    public void addPlayerIntro()
    {
        string playerName = InputPlayerNameIntro.instance.getText();

        if (string.IsNullOrEmpty(playerName))
        {
            ErrorMessageController.instance.setMessage("Please input a name");
            ErrorMessageController.instance.open(true);
        }
        else
        {
            if (validateName(playerName))
            {
                if (lastIndx >= -1 && lastIndx < listPlayer.Length - 1 && validateName(playerName))
                {
                    Game newGame = new Game();
                    Profile prof = new Profile();
                    prof.profileName = playerName;
                    newGame.currentProfile = prof;
                   

                    ++lastIndx;
                    listPlayer[lastIndx].gameObject.SetActive(true);
                    listPlayer[lastIndx].setName(playerName);

                    if (lastIndx == 0)
                    {
                        lastSelected = 0;
                        IntroCanvasController.instance.open(false);
                        MainMenu.instance.setProfileName(playerName, 0);
                        MainMenu.instance.Open(true);
                    }

                    Game.current = newGame;
                    SaveLoad.AddSavedGame(newGame);

                }
            }
            else
            {
                ErrorMessageController.instance.setMessage("Name already taken");
                ErrorMessageController.instance.open(true);
            }

        }
    }

    public void addPlayer()
    {
        string playerName = InputPlayerNameController.instance.getText();

        if (string.IsNullOrEmpty(playerName))
        {
            ErrorMessageController.instance.setMessage("Please input a name");
            ErrorMessageController.instance.open(true);
        }
        else
        {
            if (validateName(playerName))
            {
                if (lastIndx >= -1 && lastIndx < listPlayer.Length - 1)
                {
                    Game newGame = new Game();
                    Profile prof = new Profile();
                    prof.profileName = playerName;
                    prof.musicVol = 5.0f;
                    prof.effectsVol = 5.0f;
                    newGame.currentProfile = prof;
                    Game.current = newGame;
                    SaveLoad.AddSavedGame(newGame);

                    ++lastIndx;
                    listPlayer[lastIndx].gameObject.SetActive(true);
                    listPlayer[lastIndx].setName(playerName);

                    if (lastIndx == 0)
                    {
                        updateSelected(listPlayer[lastIndx].getName());
                        listPlayer[lastIndx].selected(true);
                    }

                    SaveLoad.list.latestGame = playerName;
					Debug.Log(SaveLoad.list.savedGames.Count);

                }
                else
                {
                    ErrorMessageController.instance.setMessage("Too many users");
                    ErrorMessageController.instance.open(true);
                }
            }
            else
            {
                ErrorMessageController.instance.setMessage("Name already taken");
                ErrorMessageController.instance.open(true);
            }

        }

    }

    public void deletePlayer(int indx)
    {
        if(indx <= lastIndx && indx >= 0 ) 
        {
            Game.current = null;
            SaveLoad.DeleteGame(listPlayer[indx].getName());
            for (int i = indx; i < lastIndx; ++i)
            {
                listPlayer[i].setName(listPlayer[i + 1].getName());
            }

            if(lastSelected == indx && indx > 0)
            {
                listPlayer[lastSelected].selected(false);
                lastSelected = indx - 1;
                listPlayer[lastSelected].selected(true);
                updateSelected(listPlayer[lastSelected].getName());
            }

            listPlayer[lastIndx].gameObject.SetActive(false);
            lastIndx--;

            if(lastIndx == -1)
            {
                updateSelected(null);
            }
            
        }
    }

    public void selectPlayer(int indx)
    { 

        if (indx >= 0 && indx <= lastIndx)
        {

            listPlayer[lastSelected].selected(false);
            SaveLoad.list.latestGame = listPlayer[lastSelected].getName();
            try {
                SaveLoad.list.getProfile(listPlayer[lastSelected].getName()).currentProfile.islastSelected = false;
                SaveLoad.list.getProfile(listPlayer[indx].getName()).currentProfile.islastSelected = true;
            }catch(NullReferenceException ex)
            {

            }
            listPlayer[indx].selected(true);
            lastSelected = indx;

            updateSelected(listPlayer[indx].getName());

        }

    }

    public void updateSelectedPlayer()
    {
        try
        {
            listPlayer[0].selected(false);
        }
        catch(NullReferenceException ex)
        {

        }
        if(lastSelected >= 0 && lastSelected <= lastIndx)
        {
            listPlayer[lastSelected].selected(true);
            updateSelected(listPlayer[lastSelected].getName());
            activeProfileName.text = listPlayer[lastSelected].getName();

            Debug.Log("!!!!!!!!!!!!!!!!!!" + listPlayer[lastSelected].getName());

            SaveLoad.list.latestGame = listPlayer[lastSelected].getName();
            MainMenu.instance.setProfileName(listPlayer[lastSelected].getName(), lastSelected);
            Debug.Log("new name 555555: " + listPlayer[lastSelected].getName());
            optionsController.UpdateVolume();
        }
        
    }

    public void loadPlayers()
    {

        SaveLoad.Load();

        List<Game> list = new List<Game>();

        try
        {
            list = SaveLoad.list.savedGames;

            for (int i = 0; i < list.Count && i < listPlayer.Length; i++)
            {
                listPlayer[i].gameObject.SetActive(true);
                listPlayer[i].setName(list[i].currentProfile.profileName);
            }

        }
        catch (NullReferenceException ex)
        {

        }

        Debug.Log("Number of items: " + list.Count);

        if (list.Count > 0)
        {
            lastIndx = list.Count - 1;

            int ix = 0;
              
            for(int i = 0; i < list.Count; ++i)
            {
                if (list[i].currentProfile.profileName == SaveLoad.list.latestGame)
                {
                    ix = i;
                    break;
                }
            }



            list[ix].currentProfile.islastSelected = true;
            Game.current = list[ix];
            lastSelected = ix;
            Debug.Log("Last selected: " + Game.current.currentProfile.profileName);

            updateSelectedPlayer();
            Debug.Log("profilename:::: " + Game.current.currentProfile.profileName);
			MainMenu.instance.setProfileName(Game.current.currentProfile.profileName, ix);
			MainMenu.instance.Open(true);

		}
        else
        {
            IntroCanvasController.instance.open(true);
        }

    }
       
    public bool playerExist(string x)
    {
        bool ret = false;


        for(int i = 0; i <= lastIndx; ++i)
        {
            if (listPlayer[i].getName().Equals(x))
            {
				Debug.Log(lastIndx);
                Debug.Log(listPlayer[i].getName() + "compared with " + i);
                ret = true;
                break;
            }
        }

        return ret;
    }

    public bool validateName(string x)
    {
        bool ret = false;

        if(x.Length > 0)
        {
            ret = !playerExist(x);
        }

        return ret;
    }

    public void updateSelected(string s)
    {
        if (string.IsNullOrEmpty(s) == false)
        {
            try
            {
                Game.current.currentProfile.islastSelected = false;
            }catch(NullReferenceException ex)
            {

            }


            Game.current = SaveLoad.list.getProfile(s);

            Debug.Log("============[ " + Game.current.currentProfile.money);

            Game.current.currentProfile.islastSelected = true;
            ProfileDetailsController.instance.setName(s);
        }
        else
        {
            Game.current = null;
            ProfileDetailsController.instance.setInvalid();
        }
    }



}
