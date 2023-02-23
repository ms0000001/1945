using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            cnt++;
            hit.color = new Color(1,0,0,1);
            Invoke("Hit",0.05f);   
            if(cnt == 10)
            {
                gameObject.SetActive(false);
                GameManager.score_ += 1000;
                isDead = true;
            }
        }
        if(other.tag == "bomb")
        {
            gameObject.SetActive(false);
            GameManager.score_ += 1000;
            isDead = true;
        }
    }  
}
