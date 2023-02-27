using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal_Item : MonoBehaviour
{
    private void Start() {
        Physics2D.IgnoreLayerCollision(3,6,true);
        Physics2D.IgnoreLayerCollision(3,3,true);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"||other.tag == "Hide")
        {
            GameManager.score_ += 1000;            
            Destroy(gameObject);
        }
    }
}
