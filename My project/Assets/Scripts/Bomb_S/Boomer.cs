using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{
    public static bool isFlying;

    private void Start() {
        isFlying = true;
    }
    private void FixedUpdate() 
    {
        gameObject.transform.Translate(new Vector2(0, 0.2f));
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "BoomerNet")
        {
            isFlying = false;
            gameObject.transform.Translate(new Vector2(0, -25f));

            gameObject.SetActive(false);
        }
    }
}
