using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int curCoins;
    public Text pointTxt;
    private int Point = 0;
    private const string preTextPoint = "Point: ";
    [SerializeField] private GameObject AlertPanel;
    [SerializeField] private GameObject CongratPanel;
    //public bool enhance = false;
    [SerializeField] public GameObject EnhanceWeapon;
    [SerializeField] public GameObject OriginalWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.coinText.text = "Coins:"+ curCoins.ToString();
        pointTxt = GameObject.Find("Point").GetComponent<Text>();
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
}
