using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endgame_dialog : MonoBehaviour
{
    

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}

