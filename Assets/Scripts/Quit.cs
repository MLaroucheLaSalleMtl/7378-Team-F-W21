using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//all by chenrui
public class Quit : MonoBehaviour
{
   public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
        #else
            Application.Quit();
        #endif
    }
}
