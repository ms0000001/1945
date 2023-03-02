using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    public GameObject boss;    

    void Update()
    {
        //보스 출현
        if(BossAct.isDead == false)
        {
            //생성 조건
            if(Enemy.isDead == true&&Enemy2.isDead ==true
            &&Enemy3.isDead == true)
            {
                boss.SetActive(true);
            }
        }
    }    
}
