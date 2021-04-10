using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //public static Shop instance;


    [SerializeField] public GameObject ShopPanel;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject AlertPanel;
    [SerializeField] private GameObject CongratPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ShopPanel.SetActive(true);
            AlertPanel.SetActive(false);
            CongratPanel.SetActive(false);
            Time.timeScale = 0f;
            PlayerController.instance.CancelInvoke("Shooting");
            CharacterMove.instance.CancelInvoke("rotateAiming");
            GameUI.SetActive(false);
            AudioListener.pause = true;
        }
    }

    public void Resume()
    {
        ShopPanel.SetActive(false);
        Time.timeScale = 1;
        GameUI.SetActive(true);
        AudioListener.pause = false;
    }
    public void Buy()
    {
        GameManager.instance.UseCoins(25);
        
    }

}
