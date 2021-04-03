using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    public GameObject bgm1, bgm2, bgm3, bgm4;

    public AudioClip SFX_Coin;
    public AudioClip SFX_Hit;
    public AudioClip SFX_Boost;

    public AudioSource BGM1, BGM2, BGM3, BGM4;
    private AudioSource BGM;

    public Slider BGM_Slider;
    public Slider SFX_Slider;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int num = PlayerPrefs.GetInt("SelectWeather");
        //Debug.Log(PlayerPrefs.GetFloat("BGM_Slider", 1) + " " + PlayerPrefs.GetFloat("SFX_Slider", 1));

        switch (num)
        {
            case 0:
                BGM1.volume = PlayerPrefs.GetFloat("BGM_Slider", 1);
                BGM2.volume = 0.0f;
                BGM3.volume = 0.0f;
                BGM4.volume = 0.0f;
                break;
            case 1:
                BGM1.volume = 0.0f;
                BGM2.volume = PlayerPrefs.GetFloat("BGM_Slider", 1);
                BGM3.volume = 0.0f;
                BGM4.volume = 0.0f;
                bgm2.SetActive(true);
                break;
            case 2:
                BGM1.volume = 0.0f;
                BGM2.volume = 0.0f;
                BGM3.volume = PlayerPrefs.GetFloat("BGM_Slider", 1);
                BGM4.volume = 0.0f;
                bgm3.SetActive(true);
                break;
            case 3:
                BGM1.volume = 0.0f;
                BGM2.volume = 0.0f;
                BGM3.volume = 0.0f;
                BGM4.volume = PlayerPrefs.GetFloat("BGM_Slider", 1);
                bgm4.SetActive(true);
                break;
        }

        
        BGM_Slider.value = PlayerPrefs.GetFloat("BGM_Slider", 1);
        SFX_Slider.value = PlayerPrefs.GetFloat("SFX_Slider", 1);
    }

    public void SFX_CoinPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_Coin, transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1));
    }

    public void SFX_HitPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_Hit, transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1));
    }

    public void SFX_BoostPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_Boost, transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1));
    }

    public void BGM_Volume()
    {
        PlayerPrefs.SetFloat( "BGM_Slider", BGM_Slider.value);
    }

    public void SFX_Volume()
    {
        PlayerPrefs.SetFloat("SFX_Slider", SFX_Slider.value);
    }
}
