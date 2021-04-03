using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectmanager : MonoBehaviour
{
    public Toggle Sel_Daybreak;
    public Toggle Sel_Daytime;
    public Toggle Sel_Evening;
    public Toggle Sel_Midnight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select_Weather()
    {
        if (Sel_Daybreak.isOn == true)
            PlayerPrefs.SetInt("SelectWeather", 0);
        else if (Sel_Daytime.isOn == true)
            PlayerPrefs.SetInt("SelectWeather", 1);
        else if (Sel_Evening.isOn == true)
            PlayerPrefs.SetInt("SelectWeather", 2);
        else
            PlayerPrefs.SetInt("SelectWeather", 3);
    }
}
