using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemmanager : MonoBehaviour
{
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z < Camera.transform.position.z)
            Destroy(gameObject);
        transform.Rotate(0, 0, 10f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(gameObject);
    }
}
