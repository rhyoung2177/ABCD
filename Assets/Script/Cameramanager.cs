using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour
{
    public GameObject player, Main_Camera;
    public Material Daybreak, Daytime, Evening, Midnight;

    // Start is called before the first frame update
    void Start()
    {
        int num = PlayerPrefs.GetInt("SelectWeather");

        switch (num)
        {
            case 0:
                Main_Camera.AddComponent<Skybox>().material = Daybreak;
                break;
            case 1:
                Main_Camera.AddComponent<Skybox>().material = Daytime;
                break;
            case 2:
                Main_Camera.AddComponent<Skybox>().material = Evening;
                break;
            case 3:
                Main_Camera.AddComponent<Skybox>().material = Midnight;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z-10);
        //transform.rotation = Quaternion.Euler(25, 0, 0);
    }
}
