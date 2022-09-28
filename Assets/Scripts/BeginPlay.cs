using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPlay : MonoBehaviour
{
    public GameObject SettingGr;
    public string SceenGame;
    

    public void BeginPlayGame()
    {
        SceneManager.LoadScene("level_01");
    }

    public void ChangeScreenGame()
    {
        SceneManager.LoadScene(SceenGame);
    }

    public void OpenSettingGr() {
        if (SettingGr != null) {
            bool isActive = SettingGr.activeSelf;
            SettingGr.SetActive(!isActive);
        }
    }

    
}
