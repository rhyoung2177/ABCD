using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Scenemanager : MonoBehaviour
{
    public Toggle Toggle_Mirror;
    public Material Daybreak, Daytime, Evening, Midnight;
    public GameObject Main_Camera;

    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("MirrorMode") == 1)
            Toggle_Mirror.isOn = true;
        else
            Toggle_Mirror.isOn = false;
    }

    public void MenuEnter()
    {
        SceneManager.LoadScene("MenuScene");
        
       
    }

    public void GameEnter()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
