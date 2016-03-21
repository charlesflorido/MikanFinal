using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad{

	public static ProfileList list= new ProfileList();
	public static string fileName = "savedGames.gd";

	public static void Save(){
	
		if (list.savedGames.Exists (x => x.currentProfile.profileName == Game.current.currentProfile.profileName) == true) {

			list.savedGames.RemoveAt(list.savedGames.FindIndex(x => x.currentProfile.profileName == Game.current.currentProfile.profileName));
            Debug.Log(Game.current.currentProfile.profileName + "exits. ");
		}


        Debug.Log("save");
		list.savedGames.Add (Game.current);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/" + fileName);
		bf.Serialize (file, SaveLoad.list);
		file.Close ();

        Debug.Log("[[[[[[[[[[[" + Game.current.currentProfile.money);

		Debug.Log ("save" + Application.persistentDataPath);
	
	}

	public static void Load(){

        if (!File.Exists(Application.persistentDataPath + "/" + SaveLoad.fileName))
        {
            
            Game.current = new Game();
            Game.current.currentProfile.profileName = "Default";
			list.latestGame = "Default";

            list.savedGames.Add(Game.current);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + fileName);
            bf.Serialize(file, SaveLoad.list);
            file.Close();

        }

		BinaryFormatter bfOpen = new BinaryFormatter();
		FileStream fileOpen = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
		SaveLoad.list = (ProfileList)bfOpen.Deserialize(fileOpen);
		
		fileOpen.Close();
		Debug.Log("Loaded");
		
	}
	
	public static void AddSavedGame(Game newGame){
	
		list.savedGames.Add (newGame);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/" + fileName);
		bf.Serialize (file, SaveLoad.list);
		file.Close ();
		
		Debug.Log ("save" + Application.persistentDataPath);
	
	}

	public static void DeleteGame(string name){
	
		list.savedGames.RemoveAt(list.savedGames.FindIndex(x => x.currentProfile.profileName == name));
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/" + fileName);
		bf.Serialize (file, SaveLoad.list);
		file.Close ();
		
		Debug.Log ("save" + Application.persistentDataPath);

	}

}
