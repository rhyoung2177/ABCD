using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timermanager : MonoBehaviour
{
    public Text timeText;
    public Text scoreText;
    public Text distanceText;
    public Text HPText;
    public Text HPText_Mirror;

    public GameObject Endplace;
    public GameObject Player;
    public GameObject DistancePlayer;
    public GameObject DistanceBar;

    private float time;
    private float distance;
    private int HP = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    

    private void Update()
    {
        time += Time.deltaTime;
        distance = Endplace.transform.position.z - Player.transform.position.z;
        timeText.text = string.Format("{0:N2}초", time);
        scoreText.text = "점수 : " + PlayerPrefs.GetInt("Score").ToString() + "점";
        distanceText.text = string.Format("집까지 {0:N2}m", distance);
        HPText.text = "HP : " + HP;
        HPText_Mirror.text = "HP : " + HP;

        showdistance();

        if (HP <= 0)
        {
            GameObject.Find("WindowManager").GetComponent<Windowmanager>().GameoverWindowOn();
        }
    }

    public void minusHP()
    {
        HP = HP - 1;
    }
    
    public void Stopwatch()
    {
        PlayerPrefs.SetFloat("TimeNow", time);
        PlayerPrefs.SetInt("LifeNow", HP);
        PlayerPrefs.SetFloat("ScoreNow", PlayerPrefs.GetInt("Score"));
    }

    public float returndistance()
    {
        return Player.transform.position.z;
    }

    void showdistance()
    {
        DistancePlayer.transform.position = new Vector3((DistanceBar.transform.position.x-190) + (Player.transform.position.z)/3.3f, DistanceBar.transform.position.y, 0);
    }
}
