using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip Daybreak, Daytime, Evening, Midnight;

    // Start is called before the first frame update
    void Start()
    {
        int num = PlayerPrefs.GetInt("SelectWeather");

        switch (num)
        {
            case 0:
                BGM.clip = Daybreak;
                break;
            case 1:
                BGM.clip = Daytime;
                break;
            case 2:
                BGM.clip = Evening;
                break;
            case 3:
                BGM.clip = Midnight;
                break;
        }

        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        BGM.volume = PlayerPrefs.GetFloat("BGM_Slider", 1);
    }
}
