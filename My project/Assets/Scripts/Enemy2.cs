using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject shoot_P;
    public RectTransform pos3;
    private RectTransform enemy_obj = default;
    public float speed;
    public static bool isDead =false;
    int cnt = 0;

    void Start()
    {
        enemy_obj = gameObject.GetComponent<RectTransform>();
    }
    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos3.anchoredPosition,Time.deltaTime*speed*80);        
        
    }

    void Update()
    {
        if(cnt > 0)
        {
            shoot_P.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            cnt++;            
            if(cnt == 10)
            {
                gameObject.SetActive(false);
                isDead = true;
            }
        }
    }  
}
