using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterUI : MonoBehaviour
{
    [SerializeField]
    public Text myText;
    public PlayerUnitController puc;
    public Image myImage;
    public Slider Slid;
    public bool bonded;
    //public GameObject myGameObject;

    public void Start()
    {
        Slid = this.transform.Find("Slider").GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        if (puc!=null)
        {
            Slid.value = puc.Health / puc.MaxHealth;

        }
    }
    public void SetText(string charDescription)
    {
        myText.text = charDescription;
        

        //img.sprite=myUI.UISprite;

        //myGameObject = ActOb.getGameOb();
    }

    public void Death()
    {
        //FROM OLD PROJECT NEEDS TO BE UPDATED FOR NEW ONE


        /*
        CharacterGen cg = FindObjectOfType<CharacterGen>();
        cg.Portraits.Remove(this.gameObject);
        */


        Destroy(this.gameObject);
    }

    public void Bond(GameObject bondObj)
    {
        puc = bondObj.GetComponent<PlayerUnitController>();
        
        myImage = this.transform.Find("CharPortrait").GetComponentInChildren<Image>();
        myImage.color = puc.StartCol;
        puc.bondUI(this);
        
        
    }
}
