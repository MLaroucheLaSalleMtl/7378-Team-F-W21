using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject canvas;

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
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseMenu.SetActive(true);
        canvas.SetActive(false);
    }
}
