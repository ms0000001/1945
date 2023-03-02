using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal_Item : MonoBehaviour
{
    private void Start() {
        //충돌 무시
        Physics2D.IgnoreLayerCollision(3,6,true);
        Physics2D.IgnoreLayerCollision(3,3,true);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //플레이어와 충돌 시
        if(other.tag == "Player"|| other.tag == "Hide")
        {
            GameManager.score_ += 1000;            
            Destroy(gameObject);
        }

        //맵 밖으로 이탈 시
        if(other.tag == "Net"|| other.tag == "EnemyNet")
        {
            Destroy(gameObject);
        }
    }
}
