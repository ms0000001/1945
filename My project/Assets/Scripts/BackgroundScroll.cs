using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed;  

    void Update()
    {
        Scroll();
    }
    
    private void Scroll()
    {
        transform.Translate(Vector3.down * speed *Time.deltaTime);
    }    
}
