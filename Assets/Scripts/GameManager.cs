using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int curCoins;

    
    public Text pointTxt;   //by chenrui
    private int Point = 0;   //by chenrui
    private const string preTextPoint = "Point: ";    //by chenrui
    [SerializeField] private GameObject AlertPanel;//by chenrui
    [SerializeField] private GameObject CongratPanel;//by chenrui
    //public bool enhance = false;
    [SerializeField] public GameObject EnhanceWeapon;//by chenrui
    [SerializeField] public GameObject OriginalWeapon;//by chenrui

    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.coinText.text = "Coins:"+ curCoins.ToString();
        pointTxt = GameObject.Find("Point").GetComponent<Text>();  //by chenrui
        pointTxt.text = preTextPoint + Point.ToString("D2");
        
    }

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void CollectCoins()
    {
        curCoins += 1;
        UIController.instance.coinText.text = "Coins:" + curCoins.ToString();

    }

    public void UseCoins(int coins)
    {
        //Coded by Chenrui 
        if (coins>curCoins)
        {
            AlertPanel.SetActive(true);
            
        }
        else
        {
            curCoins -= coins;
            OriginalWeapon.SetActive(false);
            EnhanceWeapon.SetActive(true);
            GameObject.Find("Character").GetComponent<PlayerController>().WeaponEnhance = true;
            CongratPanel.SetActive(true);

        }
        UIController.instance.coinText.text = "Coins:" + curCoins.ToString();

    }
    public void AddPoint()
    {
        Point += 1;
        pointTxt.text = preTextPoint + Point.ToString("D2");
    }

    public void BossAddPoint()
    {
        Point += 5;
        pointTxt.text = preTextPoint + Point.ToString("D2");
    }
    public void CloseAlert()
    {
        AlertPanel.SetActive(false);
    }
    public void CloseGongrat()
    {
        CongratPanel.SetActive(false);
    }
    //Chenrui's code ends
}
