using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject player;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        this.effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        this.effect.transform.position = new Vector3(playerPos.x, playerPos.y + 0.65f, playerPos.z - 0.8f);
    }

    public void Boost(int a)
    {
        if (a == 0)
            this.effect.SetActive(false);
        else
            this.effect.SetActive(true);
    }
}
