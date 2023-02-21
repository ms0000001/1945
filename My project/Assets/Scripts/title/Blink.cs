using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public GameObject text;
    float timer;
    float setTime1;
    float setTime2;


    void Start() {
        timer = 0;
        setTime1 = 0.5f;
        setTime2 = 1f;
    }
    void Update() {

        timer += Time.deltaTime;
        if(timer>setTime1)
        {
            text.SetActive(false);
        }
        if(timer>setTime2)
        {
            text.SetActive(true);
            timer = 0;
        }
        if(Input.anyKeyDown)
        {
            text.SetActive(true);
            setTime2 =3333f;
            timer = -333f;
        }        
    }
}
