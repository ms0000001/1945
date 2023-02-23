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
        if(Boomer.isFlying == false)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
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
