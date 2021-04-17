using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//all by chenrui
public class LoadScene : MonoBehaviour
{

    private AsyncOperation async;

    public void BtnLoadScene()
    {
        if (async != null) return;

        Scene currentScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
    }
    public void BtnLoadScene(int i)
    {
        if (async != null) return;


        async = SceneManager.LoadSceneAsync(i);
    }
    public void BtnLoadScene(string s)
    {
        if (async != null) return;


        async = SceneManager.LoadSceneAsync(s);
    }
}
