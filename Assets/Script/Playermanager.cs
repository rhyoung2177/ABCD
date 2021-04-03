using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Playermanager : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody CatRigid;
    float jumpForce = 350.0f;
    float Speed = 0.3f;
    float CatSpeed = 0.3f;
    Animator Catani;
    //public Text touchText;

    public AudioClip SFX_Coin;
    public AudioClip SFX_Hit;

    public GameObject Cat;

    GameObject Player;

    private bool HitOK = false;

    // Start is called before the first frame update
    void Start()
    {
        this.CatRigid = GetComponent<Rigidbody>();
        this.Catani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("a") )
           this.transform.Translate(-1, 0, 0);
       if (Input.GetKeyDown("d"))
           this.transform.Translate(1,0,0);

        Vector3 move = Input.acceleration;

        //if (Input.GetMouseButtonDown(0))
        //    startPos = Input.mousePosition;
        ////if (Input.touchCount > 0)
        ////{
        ////    float swipeLength = Input.GetTouch(0).deltaPosition.y;
        ////    if (swipeLength >= 200 && this.transform.position.y <= 0.31)
        ////        this.CatRigid.AddForce(transform.up * this.jumpForce);
        ////    swipeLength = Input.GetTouch(1).deltaPosition.y;
        ////    if (swipeLength >= 200 && this.transform.position.y <= 0.31)
        ////        this.CatRigid.AddForce(transform.up * this.jumpForce);
        ////    else;
        ////}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //        Vector2 endPos = Input.mousePosition;
        //        float swipeLength = (endPos.y - this.startPos.y);
        //        if (swipeLength >= 200 && this.transform.position.y <= 0.31)
        //            this.CatRigid.AddForce(transform.up * this.jumpForce);
        //}
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).deltaPosition.y > 100 && this.transform.position.y <= 0.31)
                this.CatRigid.AddForce(transform.up * this.jumpForce);
        }
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).deltaPosition.y > 100 && this.transform.position.y <= 0.31)
                this.CatRigid.AddForce(transform.up * this.jumpForce);
        }
        else;

            this.transform.Translate(0, 0, CatSpeed);
        if (this.transform.position.x >= -2.0 && this.transform.position.x <= 2.0)
            this.transform.Translate(move.x * Speed, 0, 0);
        else if (this.transform.position.x < -2.0)
            this.transform.Translate(0.3f, 0, 0);
        else if (this.transform.position.x > 2.0)
            this.transform.Translate(-0.3f, 0, 0);
        else;

        this.Catani.speed = 2.0f;
        if(CatSpeed >= 0.6f)
            this.Catani.speed = 4.0f;
    }

    

    public void windowon(float a)
    {
        Speed = a;
    }

    public void CatBooster(float a)
    {
        CatSpeed = a;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Ending")
        {
            GameObject.Find("TimerManager").GetComponent<Timermanager>().Stopwatch();
            GameObject.Find("WindowManager").GetComponent<Windowmanager>().EndingWindowOn();
        }

        if (other.tag == "Coin")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
            AudioSource.PlayClipAtPoint(SFX_Coin, transform.position, PlayerPrefs.GetFloat("SFX_Slider",1));
            GetComponent<ParticleSystem>().Play();
        }

        if (other.tag == "RCoin")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 50);
            AudioSource.PlayClipAtPoint(SFX_Coin, transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1));
            GetComponent<ParticleSystem>().Play();
        }

        if (HitOK == false && other.tag == "obstacle")
        {
            GameObject.Find("TimerManager").GetComponent<Timermanager>().minusHP();
            AudioSource.PlayClipAtPoint(SFX_Hit, transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1));
            HitOK = true;
            Twinkling1();
            Invoke("Twinkling3", 0.4f);
        }
    }

    void Twinkling1()
    {
        Cat.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Invoke("Twinkling2", 0.2f);
    }
    void Twinkling2()
    {
        Cat.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }
    void Twinkling3()
    {
        Cat.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Invoke("Twinkling4", 0.2f);
    }
    void Twinkling4()
    {
        Cat.GetComponent<SkinnedMeshRenderer>().enabled = true;
        HitOK = false;
    }

    bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position
            = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
