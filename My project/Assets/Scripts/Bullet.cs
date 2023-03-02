using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //맵 밖으로 이탈 시
        if(other.tag == "BulletNet")
        {
            gameObject.SetActive(false);            
        }
        //적과 충돌 시
        if(other.tag == "Enemy")
        {
            gameObject.SetActive(false);            
        }
    }
}
