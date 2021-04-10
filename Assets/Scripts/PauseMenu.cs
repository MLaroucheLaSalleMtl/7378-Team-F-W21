using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject GameUI;
    [SerializeField] public GameObject settingMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Paused = false;
        pauseMenu.SetActive(false);
        GameUI.SetActive(true);
        AudioListener.pause = false;
        GameObject.Find("Character").GetComponent<PlayerController>().pause = false;
        settingMenu.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseMenu.SetActive(true);
        //canvas.SetActive(false);
        PlayerController.instance.CancelInvoke("Shooting");
        GameUI.SetActive(false);
        AudioListener.pause = true;
        GameObject.Find("Character").GetComponent<PlayerController>().pause = true;
    }

    public void setting()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
        PlayerController.instance.CancelInvoke("Shooting");
        GameUI.SetActive(false);
        AudioListener.pause = false;
        GameObject.Find("Character").GetComponent<PlayerController>().pause = true;
    }

    public void OpenPause()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
        PlayerController.instance.CancelInvoke("Shooting");
        GameUI.SetActive(false);
        AudioListener.pause = true;
        GameObject.Find("Character").GetComponent<PlayerController>().pause = true;
    }

}
