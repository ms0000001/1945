using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject S_point;
    public RectTransform pos3;
    private RectTransform enemy_obj = default;
    public float speed;
    int cnt = 0;
    void Start()
    {
        enemy_obj = gameObject.GetComponent<RectTransform>();
        S_point = GetComponent<GameObject>();
    }
    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos3.anchoredPosition,Time.deltaTime*speed*100);        
        
    }

    void Update()
    {
        
    }    

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            cnt++;
            if(cnt > 1)
            {
                S_point.SetActive(true);
            }
            if(cnt == 10)
            {
                gameObject.SetActive(false);
            }
        }
    }  
}
