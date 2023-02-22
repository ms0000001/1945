using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    
    public GameObject boss;

    void Start()
    {
        
    }

    void Update()
    {
        if(BossAct.isDead == false)
        {
            if(Enemy.isDead == true&&Enemy2.isDead ==true)
            {
                boss.SetActive(true);
            }
        }
    }
}
