using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settingmanager : MonoBehaviour
{
    public Toggle Toggle_Mirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("ResultThird", 2500.0f);
        PlayerPrefs.SetFloat("ResultSecond", 5000.0f);
        PlayerPrefs.SetFloat("ResultFirst", 7500.0f);
    }

    public void MirrorModeOn()
    {
        if (Toggle_Mirror.isOn == true)
            PlayerPrefs.SetInt("MirrorMode", 1);
        else
            PlayerPrefs.SetInt("MirrorMode", 0);
    }
}
