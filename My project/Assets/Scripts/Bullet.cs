using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "BulletNet")
        {
            gameObject.SetActive(false);            
        }
        if(other.tag == "Enemy")
        {
            gameObject.SetActive(false);            
        }
    }
}
