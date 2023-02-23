using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float size = 0.3f; //원하는 사이즈
    public float speed; //커질 때의 속도

    private float time;
    private Vector2 originScale; //원래 크기

    private void Awake()
    {
        originScale = transform.localScale; //원래 크기 저장
    }
    private void OnEnable()
    {
        StartCoroutine(Up());
    }
    IEnumerator Up()
    {
        while (transform.localScale.x > size)
        {
            transform.localScale = originScale / (1f + time * speed);
            time += Time.deltaTime;

            if (transform.localScale.x <= size)
            {
                transform.localScale = originScale;
                time = 0;                
                break;
            }
            yield return null;
        }
    }
    private void OnDisable()
    {
        gameObject.transform.localScale = originScale;
    }
}
