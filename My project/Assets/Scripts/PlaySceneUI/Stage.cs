using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject stageClaerOff;
    float timer;
    float setTime;
    
    void Start()
    {
        stageClaerOff.SetActive(false);
        timer = 0;
        setTime = 3f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(setTime < timer)
        {
            this.gameObject.SetActive(false);
        }
    }
}
