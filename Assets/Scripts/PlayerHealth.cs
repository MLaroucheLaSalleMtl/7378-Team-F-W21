using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float maxHealth = 100.0f;
    public float curHealth;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

        UIController.instance.playerHealthBar.maxValue = maxHealth;
        UIController.instance.playerHealthBar.value = curHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer()
    {
        curHealth-=10;
        if (curHealth <= 0)
        {
            CharacterMove.instance.gameObject.SetActive(false);
            UIController.instance.gameOverScreen.SetActive(true);
            UIController.instance.canvas.SetActive(false);

        }
        UIController.instance.playerHealthBar.value = curHealth;
    }
    public void Healing()
    {
        curHealth = maxHealth;
        UIController.instance.playerHealthBar.value = maxHealth;
    }
}
