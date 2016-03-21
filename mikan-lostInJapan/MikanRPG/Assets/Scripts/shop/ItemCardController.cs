
using UnityEngine;
using UnityEngine.UI;

public class ItemCardController : MonoBehaviour {

	public ItemController []items;
	public Text quantity;
    public bool hasQuantity = true;

	private string answerName;
	private int answerNum;
    

	public Text textName;
	public Text textNum;
    public Button btnSendItem;


	public ShopCustomerNumController customerNum;
	public ShopLifeController lifeNum;


	private Animator anim;

    private int decoy;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	


	public void answer(){
        btnSendItem.gameObject.SetActive(false);
        textNum.text = "";  

		if (ItemSelectedController.getSelectedItem ().getText () == answerName) {
            if (hasQuantity)
            {
                if(int.TryParse(quantity.text, out decoy) && answerNum == int.Parse(quantity.text))
                {
                    ShopSounds1.instance.playSound("win");
                }
                else
                {
                    ShopSounds1.instance.playSound("fail");
                    lifeNum.reduceScore();

                }
            }
            else
            {
                ShopSounds1.instance.playSound("win");
            }

		} else {
			ShopSounds1.instance.playSound("fail");
			lifeNum.reduceScore();
		}


		customerNum.reduceCustomers();
        anim.SetInteger("animState", 2);
    }

	public void generateQuestion(){
		answerName = randomItem ();
		answerNum = Random.Range (1, 10);
		textName.text = JapaneseTranslator.translate (answerName);
		textNum.text = "" + JapaneseTranslator.number (answerNum);
        anim.SetInteger("animState", 1);

        btnSendItem.gameObject.SetActive(true);

    }

	string randomItem(){
		int num = Random.Range (0, items.Length);

		return items [num].getText();
	}




}
