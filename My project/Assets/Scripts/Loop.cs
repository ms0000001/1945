using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    float h;
        RectTransform rectTransform;        

    private void Awake() {
        BoxCollider2D bg = GetComponent<BoxCollider2D>();

        h = bg.size.y;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(rectTransform.transform.position.y <= -h)
        {
            Reposition();
        }
    }
    void Reposition()
    {
        Vector2 offset = new Vector2(0,h*2f);
        rectTransform.transform.position = 
        (Vector2) rectTransform.transform.position+offset;
    }
}
