using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{
    public static bool isFlying;

    private void Start() {
        isFlying = true;
    }

    //이동
    private void FixedUpdate() 
    {
        gameObject.transform.Translate(new Vector2(0, 0.2f));
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //경계 충돌 시 비활성화
        if(other.tag == "BoomerNet")
        {
            isFlying = false;

            //재배치
            gameObject.transform.Translate(new Vector2(0, -25f));
            
            gameObject.SetActive(false);
        }
    }
}
