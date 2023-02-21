using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public RectTransform pos1;
    private RectTransform enemy_obj = default;
    public float speed;
    public static bool isDead = false;


    void Start()
    {
        enemy_obj = gameObject.GetComponent<RectTransform>();
    }

    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos1.anchoredPosition,Time.deltaTime*speed*80);        
        
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            gameObject.SetActive(false);
            isDead = true;
        }
        
        if(other.tag == "EnemyNet")
        {
            Debug.Log("벽과 충돌");
            gameObject.SetActive(false);
        }
    }    
}
