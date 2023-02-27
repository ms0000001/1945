using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Item : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float randomX,randomY;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3,6,true);
        Physics2D.IgnoreLayerCollision(3,3,true);        
        randomX = Random.Range(-1.0f, 2.0f);
        randomY = -2f;

        Rigidbody2D rigid2D = gameObject.GetComponent<Rigidbody2D>();
        rigid2D.velocity = new Vector2(randomX, randomY);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"||other.tag == "Hide")
        {
            GameManager.score_ += 1000;            
            Destroy(gameObject);
        }        
    }
}
