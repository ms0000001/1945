using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        
        if(other.tag == "EnemyNet")
        {
            gameObject.SetActive(false);
        }

        if(other.tag == "bomb")
        {
            gameObject.SetActive(false);
        }
    } 
}
