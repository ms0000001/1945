using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Image image;
    public GameObject mobDie;
    Image hit;
    public GameObject shoot_P;
    public RectTransform pos3;
    private RectTransform enemy_obj = default;
    public float speed;
    public static bool isDead =false;
    int cnt = 0;

    void Start()
    {
        isDead =false;
        hit = GetComponent<Image>();
        enemy_obj = gameObject.GetComponent<RectTransform>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        image = GetComponent<Image>();
        boxCollider2D.enabled = true;
        image.enabled = true;
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

    void Hit()
    {
        hit.color = new Color(1,1,1,1);
    }

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            cnt++;
            hit.color = new Color(1,0,0,1);
            Invoke("Hit",0.05f);   
            if(cnt == 10)
            {
                boxCollider2D.enabled = false;
                image.enabled = false;
                mobDie.SetActive(true);
                Invoke("Obj_False",0.5f);
                GameManager.score_ += 1000;
                isDead = true;
            }
        }
        if(other.tag == "bomb")
        {
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 1000;
            isDead = true;
        }
    }  
}
