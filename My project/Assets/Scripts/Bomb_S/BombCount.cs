using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCount : MonoBehaviour
{
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    void Update()
    {
        Count();
    }

    //{ 화면에 표시되는 폭탄 개수
    void Count()
    {
        //사망 시 비활성화
        if(PlayerController.isDead == false)
        {
            //폭탄 개수에 따라 활성화
            switch(PlayerController.bombCnt)
            {
                case 3:
                bomb1.SetActive(true);
                break;
                case 2:
                bomb2.SetActive(true);
                break;
                case 1:
                bomb3.SetActive(true);
                break;
                case 0:
                break;
            }

            //폭탄 사용 중, 일시정지 시 조작 불가
            if(Boomer.isFlying == false && Time.timeScale == 1)
            {
                if(Input.GetKeyDown(KeyCode.B))
                {
                    //사용 시 비활성화
                    switch(PlayerController.bombCnt)
                    {
                        case 3:
                        bomb1.SetActive(false);
                        break;
                        case 2:
                        bomb2.SetActive(false);
                        break;
                        case 1:
                        bomb3.SetActive(false);
                        break;
                        case 0:
                        break;
                    }
                }
            }
        }
    }  
    //} 화면에 표시되는 폭탄 개수
}
