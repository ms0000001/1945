using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject ex1;
    public GameObject ex2;

    void Update()
    {
        //폭발 애니메이션 활성화
        if(PlayerController.isDead == false)
        {
            if(Boomer.isFlying == false && Time.timeScale == 1)
            {
                if(PlayerController.bombCnt > 0)
                {
                    if(Input.GetKeyDown(KeyCode.B))
                    {
                        //활성화 딜레이
                        Invoke("TurnOn",1.5f);
                    }
                }
            }
        }    
    }

    void TurnOn()
    {
        ex1.SetActive(true);
        ex2.SetActive(true);
    }
}
