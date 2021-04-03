using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetmanager : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < Camera.transform.position.z-80.0f && gameObject.transform.position.z > 0)
            Destroy(gameObject);
    }
}
