using UnityEngine;
using UnityEngine.UI;


public class RandomAnimal : MonoBehaviour {

	public Sprite[] sprites;
	public string resourceName;
	public int currentSprite = -1;
	public Image animal;


	// Use this for initialization
	void Start () {

		animal = gameObject.GetComponent<Image> ();

		if(resourceName != ""){

			LoadSprite(resourceName);

		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void LoadSprite(string resourceName){

		sprites = Resources.LoadAll<Sprite>(resourceName);

		animal.sprite = sprites[Random.Range(0, sprites.Length)];

	}
}
