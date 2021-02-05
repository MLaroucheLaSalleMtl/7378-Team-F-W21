using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] panels = null; //list all panels
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        PanelToggle(0);
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    public void PanelToggle(int position)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i); //enable or disable panel
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
