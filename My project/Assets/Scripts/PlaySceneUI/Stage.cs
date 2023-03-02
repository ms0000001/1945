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
        //클리어 UI 비활성화
        stageClaerOff.SetActive(false);
        timer = 0;
        setTime = 3f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        //스테이지 시작 3초 뒤 비활성화
        if(setTime < timer)
        {
            this.gameObject.SetActive(false);
        }
    }
}
