using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputPlayerNameIntro : MonoBehaviour {

    public static InputPlayerNameIntro instance;

    private InputField text;

    void Start()
    {
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
