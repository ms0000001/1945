using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    float timer;
    float setTime;
    void Start()
    {
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
