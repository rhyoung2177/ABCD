using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject streetPrefab;
    public GameObject coinPrefab;
    public GameObject RcoinPrefab;
    public GameObject Camera;

    public GameObject human_grandpa;
    public GameObject human_grandma;
    public GameObject human_father;
    public GameObject human_mother;
    public GameObject human_child;
    public GameObject parkinggate;
    public GameObject infosign;
    public GameObject colamachine;
    public GameObject trashbin;
    public GameObject tree;
    public GameObject bus_blue;
    public GameObject bus_yellow;
    public GameObject car_police;
    public GameObject car_taxi;
    public GameObject car_red;
    public GameObject car_yellow;
    public GameObject car_green;
    public GameObject car_blue;

    private float distance;
    private int num, num1, num2;
    GameObject Coin;
    GameObject Obstacle1, Obstacle2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject street = Instantiate(streetPrefab) as GameObject;
        street.transform.position = new Vector3(0, 3, 55);
        street.transform.localScale = new Vector3(1, 1, 1.3f);
        CoinGenerate();        
    }

    private void StreetGenerate()
    {
            GameObject street = Instantiate(streetPrefab) as GameObject;
            street.transform.position = new Vector3(0, 3, distance+120);
    }

    private void CoinGenerate()
    {
        int ran = Random.Range(0, 3);
        ran = (ran - 1);
        float rando = ran * 1.75f; 
        
        for (int j = 0; j < 30; j++)
        {
            int rran = Random.Range(0, 10);

            if (rran != 5)
                Coin = Instantiate(coinPrefab) as GameObject;
            else
                Coin = Instantiate(RcoinPrefab) as GameObject;

            Coin.transform.position = new Vector3(ran, 1.5f, distance + 40 + j);
        }
        
    }

    private void ObstacleGenerate()
    {
        int ran1 = Random.Range(0, 18);

        switch (ran1)
        {
            case 0:
                Obstacle1 = Instantiate(human_grandpa) as GameObject;
                break;
            case 1:
                Obstacle1 = Instantiate(human_grandma) as GameObject;
                break;
            case 2:
                Obstacle1 = Instantiate(human_father) as GameObject;
                break;
            case 3:
                Obstacle1 = Instantiate(human_mother) as GameObject;
                break;
            case 4:
                Obstacle1 = Instantiate(human_child) as GameObject;
                break;
            case 5:
                Obstacle1 = Instantiate(infosign) as GameObject;
                break;
            case 6:
                Obstacle1 = Instantiate(colamachine) as GameObject;
                break;
            case 7:
                Obstacle1 = Instantiate(trashbin) as GameObject;
                break;
            case 8:
                Obstacle1 = Instantiate(tree) as GameObject;
                break;
            case 9:
                Obstacle1 = Instantiate(bus_blue) as GameObject;
                break;
            case 10:
                Obstacle1 = Instantiate(bus_yellow) as GameObject;
                break;
            case 11:
                Obstacle1 = Instantiate(car_blue) as GameObject;
                break;
            case 12:
                Obstacle1 = Instantiate(car_green) as GameObject;
                break;
            case 13:
                Obstacle1 = Instantiate(car_police) as GameObject;
                break;
            case 14:
                Obstacle1 = Instantiate(car_red) as GameObject;
                break;
            case 15:
                Obstacle1 = Instantiate(car_taxi) as GameObject;
                break;
            case 16:
                Obstacle1 = Instantiate(car_yellow) as GameObject;
                break;
            case 17:
                Obstacle1 = Instantiate(parkinggate) as GameObject;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = GameObject.Find("TimerManager").GetComponent<Timermanager>().returndistance();
        //if (((int)distance + 120) % 60 == 0)
        //{
        //    StreetGenerate();
        //}
        if (num2 != ((int)distance + 120) / 60)
        {
            if (((int)distance + 120) % 60 == 0)
            {
                num2 = ((int)distance + 120) / 60;
                StreetGenerate();
            }
        }
        if (num != (int)distance / 40)
        {
            if ((int)distance % 40 == 0)
            {
                num = (int)distance / 40;
                CoinGenerate();
            }
            Coin.transform.Rotate(0, 0, 10f);
        }
        if (num1 != (int)distance / 30)
        {
            if ((int)distance % 30 == 0)
            {
                int ran0 = Random.Range(0, 3);
                ran0 = (ran0 - 1);
                ObstacleGenerate();
                Obstacle1.transform.position = new Vector3(ran0*1.5f, 0.35f, distance + 60);
                if (ran0 == -1)
                    ran0 = 0;
                else if (ran0 == 0)
                    ran0 = 1;
                else
                    ran0 = -1;
                ObstacleGenerate();
                Obstacle1.transform.position = new Vector3(ran0*1.5f, 0.35f, distance + 60);
                num1 = (int)distance / 30;
            }
        }
    }
}
