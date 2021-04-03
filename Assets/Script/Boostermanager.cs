using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boostermanager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    float speed = 0.3f;
    int a = 0;
    public AudioClip SFX_Boost;

    private void Update()
    {
        GameObject.Find("Cat").GetComponent<Playermanager>().CatBooster(speed);
        GameObject.Find("EffectManager").GetComponent<EffectManager>().Boost(a);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(a==0)
            AudioSource.PlayClipAtPoint(SFX_Boost, GameObject.Find("Cat").GetComponent<Playermanager>().transform.position, PlayerPrefs.GetFloat("SFX_Slider", 1)/2);
        speed = 0.6f;
        a = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        speed = 0.3f;
        a = 0;
    }

}