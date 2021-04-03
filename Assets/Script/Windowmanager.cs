using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Windowmanager : MonoBehaviour
{
    public Text ScoreText, LifeText, TimeText;
    public Text nowText, firstText, secondText, thirdText;
    GameObject SettingCanvas, HowtoCanvas, PauseCanvas, EndingCanvas, GameoverCanvas;
    public GameObject MapCanvas, LoadingCanvas;
    public GameObject image1, image2, image3, image4, image5, image6;
    int LogID;

    public GameObject BT_Booster;
    public GameObject Text_HP;
    public GameObject BT_Booster_Mirror;
    public GameObject Text_HP_Mirror;

    int nowscore;

    // Start is called before the first frame update
    void Start()
    {
        this.SettingCanvas = GameObject.Find("Canvas_Setting");
        this.SettingCanvas.SetActive(false);
        this.HowtoCanvas = GameObject.Find("Canvas_Howto");
        this.HowtoCanvas.SetActive(false);
        this.PauseCanvas = GameObject.Find("Canvas_Pause");
        this.PauseCanvas.SetActive(false);
        this.EndingCanvas = GameObject.Find("Canvas_Ending");
        this.EndingCanvas.SetActive(false);
        this.GameoverCanvas = GameObject.Find("Canvas_Gameover");
        this.GameoverCanvas.SetActive(false);

        this.image2.SetActive(false);
        this.image3.SetActive(false);
        this.image4.SetActive(false);
        this.image5.SetActive(false);
        this.image6.SetActive(false);
        
        this.MapCanvas.SetActive(false);
        this.LoadingCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseCanvas.activeSelf == true)
        {
            GameObject.Find("Cat").GetComponent<Playermanager>().CatBooster(0.0f);
            GameObject.Find("Cat").GetComponent<Playermanager>().windowon(0.0f);
        }
        else
            GameObject.Find("Cat").GetComponent<Playermanager>().windowon(0.3f);
        MirrorMode();
    }

    public void SettingWindowOn()
    {
        this.SettingCanvas.SetActive(true);
    }

    public void SettingWindowOff()
    {
        this.SettingCanvas.SetActive(false);
    }

    public void HowtoWindowOn()
    {
        this.HowtoCanvas.SetActive(true);
    }

    public void HowtoWindowOff()
    {
        this.HowtoCanvas.SetActive(false);
    }

    public void PauseWindowOn()
    {
        this.PauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseWindowOff()
    {
        this.PauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void EndingWindowOn()
    {
        Time.timeScale = 0;

        ScoreText.text = ((int)PlayerPrefs.GetFloat("ScoreNow")).ToString();
        LifeText.text = (PlayerPrefs.GetInt("LifeNow") * 1000).ToString();
        TimeText.text = ((int)(PlayerPrefs.GetFloat("TimeNow") * 100)).ToString();

        nowscore = (int)PlayerPrefs.GetFloat("ScoreNow") + PlayerPrefs.GetInt("LifeNow") * 1000 - (int)(PlayerPrefs.GetFloat("TimeNow") * 100);
        CalculResult();

        PlayerPrefs.SetFloat("ResultNow", nowscore);
        nowText.text = "My Score : " + nowscore;
        firstText.text = "1st Score : " + PlayerPrefs.GetFloat("ResultFirst");
        secondText.text = "2nd Score : " + PlayerPrefs.GetFloat("ResultSecond");
        thirdText.text = "3rd Score : " + PlayerPrefs.GetFloat("ResultThird");
        this.EndingCanvas.SetActive(true);
    }

    public void GameoverWindowOn()
    {
        this.GameoverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameoverWindowOff()
    {
        this.GameoverCanvas.SetActive(false);
    }

    private void CalculResult()
    {
        if (PlayerPrefs.GetFloat("ResultThird") < (float)nowscore && PlayerPrefs.GetFloat("ResultSecond") > (float)nowscore && PlayerPrefs.GetFloat("ResultFirst") > (float)nowscore)
            PlayerPrefs.SetFloat("ResultThird", (float)nowscore);
        else if (PlayerPrefs.GetFloat("ResultSecond") < (float)nowscore && PlayerPrefs.GetFloat("ResultFirst") > (float)nowscore)
        {
            PlayerPrefs.SetFloat("ResultThird", PlayerPrefs.GetFloat("ResultSecond"));
            PlayerPrefs.SetFloat("ResultSecond", (float)nowscore);
        }
        else if (PlayerPrefs.GetFloat("ResultFirst") < (float)nowscore)
        {
            PlayerPrefs.SetFloat("ResultThird", PlayerPrefs.GetFloat("ResultSecond"));
            PlayerPrefs.SetFloat("ResultSecond", PlayerPrefs.GetFloat("ResultFirst"));
            PlayerPrefs.SetFloat("ResultFirst", (float)nowscore);
        }
        else
            return;
    }

    public void EndingWindowOff()
    {
        Time.timeScale = 1;
        this.EndingCanvas.SetActive(false);
    }

    public void MirrorMode()
    {
        if (PlayerPrefs.GetInt("MirrorMode") == 1)
        {
            BT_Booster.SetActive(false);
            Text_HP.SetActive(false);
            BT_Booster_Mirror.SetActive(true);
            Text_HP_Mirror.SetActive(true);
        }
        else
        {
            BT_Booster.SetActive(true);
            Text_HP.SetActive(true);
            BT_Booster_Mirror.SetActive(false);
            Text_HP_Mirror.SetActive(false);
        }
    }

    public void SelectMap()
    {
        this.MapCanvas.SetActive(true);
    }

    public void PushGame()
    {
        this.LoadingCanvas.SetActive(true);
        this.MapCanvas.SetActive(false);
    }

    public void BtLeftDown()
    {
        if (LogID != 0)
            LogID--;
    }

    public void BtRightDown()
    {
        if (LogID != 5)
            LogID++;
    }

    public void ShowHowTo()
    {
        switch (LogID)
        {
            case 0:
                this.image1.SetActive(true);
                this.image2.SetActive(false);
                this.image3.SetActive(false);
                this.image4.SetActive(false);
                this.image5.SetActive(false);
                this.image6.SetActive(false);
                break;
            case 1:
                this.image1.SetActive(false);
                this.image2.SetActive(true);
                this.image3.SetActive(false);
                this.image4.SetActive(false);
                this.image5.SetActive(false);
                this.image6.SetActive(false);
                break;
            case 2:
                this.image1.SetActive(false);
                this.image2.SetActive(false);
                this.image3.SetActive(true);
                this.image4.SetActive(false);
                this.image5.SetActive(false);
                this.image6.SetActive(false);
                break;
            case 3:
                this.image1.SetActive(false);
                this.image2.SetActive(false);
                this.image3.SetActive(false);
                this.image4.SetActive(true);
                this.image5.SetActive(false);
                this.image6.SetActive(false);
                break;
            case 4:
                this.image1.SetActive(false);
                this.image2.SetActive(false);
                this.image3.SetActive(false);
                this.image4.SetActive(false);
                this.image5.SetActive(true);
                this.image6.SetActive(false);
                break;
            case 5:
                this.image1.SetActive(false);
                this.image2.SetActive(false);
                this.image3.SetActive(false);
                this.image4.SetActive(false);
                this.image5.SetActive(false);
                this.image6.SetActive(true);
                break;
        }
    }
}
