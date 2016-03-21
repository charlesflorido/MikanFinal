using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreNumber : MonoBehaviour {

    public static ScoreNumber instance;

    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        Update();
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

    public void Update()
    {
        text.text = PlayGlobalVariables.money + "";
    }





}
