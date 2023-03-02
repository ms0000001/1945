using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSps : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    void Update()
    {   
        //공격 패턴
        if(BossAct.cnt < 20)
        {
            transform.Rotate(new Vector3 (0,0,3f));
        }
        if(BossAct.cnt >= 20&&BossAct.cnt<40)
        {
            transform.Rotate(new Vector3 (0,0,-2f));
        }
        if(BossAct.cnt >= 40&&BossAct.cnt<50)
        {
            transform.Rotate(new Vector3 (0,0,5f));
        }
        if(BossAct.cnt >= 50&&BossAct.cnt<60)
        {
            transform.Rotate(new Vector3 (0,0,-6f));
        }
        if(BossAct.cnt >= 60&&BossAct.cnt<80)
        {
            transform.Rotate(new Vector3 (0,0,11f));
        }
        if(BossAct.cnt >= 80&&BossAct.cnt<101)
        {
            transform.Rotate(new Vector3 (0,0,-13f));
        }
    }    
}
