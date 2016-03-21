using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputPlayerNameController : MonoBehaviour {

    public static InputPlayerNameController instance;

    private InputField text;

	void Start () {
        text = GetComponent<InputField>();
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

    public string getText()
    {
        return text.text;
    }

}
