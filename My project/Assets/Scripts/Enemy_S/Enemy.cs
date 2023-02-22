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
        isDead = false;
        enemy_obj = gameObject.GetComponent<RectTransform>();
    }

    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos1.anchoredPosition,Time.deltaTime*speed*80);        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            gameObject.SetActive(false);
            GameManager.score_ += 400;
            isDead = true;
        }
        
        if(other.tag == "EnemyNet")
        {
            gameObject.SetActive(false);
            isDead = true;
        }
    }    
}
