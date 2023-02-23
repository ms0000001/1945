using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mobDie;
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

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            mobDie.SetActive(true);
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
            isDead = true;
        }
        if(other.tag == "bomb")
        {
            mobDie.SetActive(true);
            Invoke("Obj_False",0.5f);
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
