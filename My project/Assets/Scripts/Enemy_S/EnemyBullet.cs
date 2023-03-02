using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //플레이어와 충돌 시
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        //맵 밖으로 이탈 시
        if(other.tag == "EnemyNet")
        {
            gameObject.SetActive(false);
        }

        if(other.tag == "BulletNet")
        {
            gameObject.SetActive(false);
        }
        //폭탄과 충돌 시
        if(other.tag == "bomb")
        {
            gameObject.SetActive(false);
        }
    } 
}
