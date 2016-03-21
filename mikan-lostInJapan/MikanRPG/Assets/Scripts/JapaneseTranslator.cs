using UnityEngine;
using System.Collections;

public class JapaneseTranslator : MonoBehaviour {

	public static string translate(string word){
		string retval = "";

		word = word.ToLower ();

		switch (word) {
			case "plate": retval = "Osara"; break;
			case "cup": retval = "kappu"; break;
			case "chopsticks": retval = "Hashi"; break;
			case "paper": retval = "Kami"; break;
			case "book": retval = "Hon"; break;
			case "notebook": retval = "No-to"; break;
			case "pencil": retval = "Enpitsu"; break;
			case "cellphone": retval = "Keitaidenwa"; break;
			case "laptop": retval = "No-topasokon"; break;
		}

		return retval;
	}

	public static string number(int n){
		string retval = "";
		switch (n) {
			case 1: retval = "ichi"; break;
			case 2: retval = "ni"; break;
			case 3: retval = "san"; break;
			case 4: retval = "yon"; break;
			case 5: retval = "go"; break;
			case 6: retval = "roku"; break;
			case 7: retval = "nana"; break;
			case 8: retval = "hachi"; break;
			case 9: retval = "kyuu"; break;
			case 10: retval = "juu"; break;

		}

		return retval;

	}
}
