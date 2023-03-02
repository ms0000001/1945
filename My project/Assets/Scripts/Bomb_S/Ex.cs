using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex : MonoBehaviour
{
    public GameObject explose1;
    public GameObject explose2;
    public GameObject explose3;
    public GameObject explose4;
    public GameObject explose5;
    public GameObject explose6;
    public GameObject explose7;
    public GameObject explose8;
    public GameObject explose9;
    public GameObject explose10;
    public GameObject explose11;
    public GameObject explose12;
    public GameObject explose13;
    public GameObject explose14;
    public GameObject explose15;

    public static bool isExpolsing;


    float timer;
    float setTime1;
    float setTime2;
    float setTime3;
    float setTime4;
    float setTime5;

    void Start()
    {
        isExpolsing = false;
        timer = 0;
        setTime1 = 0.3f;
        setTime2 = 0.6f;
        setTime3 = 0.9f;
        setTime4 = 1.2f;
        setTime5 = 1.5f;
    }

    void Update()
    {
        //폭발 애니메이션
        timer += Time.deltaTime;
        if(setTime2>timer&&timer>setTime1)
        {
            explose1.SetActive(true);
            explose2.SetActive(true);
            explose3.SetActive(true);
            explose4.SetActive(true);
        }
        if(setTime3>timer&&timer>setTime2)
        {
            explose5.SetActive(true);
            explose6.SetActive(true);
            explose7.SetActive(true);
            explose8.SetActive(true);

        }
        if(setTime4>timer&&timer>setTime3)
        {
            explose9.SetActive(true);
            explose10.SetActive(true);
            explose11.SetActive(true);

            explose1.SetActive(false);
            explose2.SetActive(false);
            explose3.SetActive(false);
            explose4.SetActive(false);

            
        }        
        if(setTime5>timer&&timer>setTime4)
        {
            explose12.SetActive(true);
            explose13.SetActive(true);
            explose14.SetActive(true);
            explose15.SetActive(true);

            explose5.SetActive(false);
            explose6.SetActive(false);
            explose7.SetActive(false);
            explose8.SetActive(false);

        }if(timer>setTime5)
        {
            explose9.SetActive(false);
            explose10.SetActive(false);
            explose11.SetActive(false);
            explose12.SetActive(false);
            explose13.SetActive(false);
            explose14.SetActive(false);
            explose15.SetActive(false);
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
