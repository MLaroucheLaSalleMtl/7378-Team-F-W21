using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider playerHealthBar;

    public GameObject gameOverScreen;
    public GameObject canvas;
    public Text coinText;

    public string gameScene;
    public string menuScene;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
