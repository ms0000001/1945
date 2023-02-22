using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAct : MonoBehaviour
{
    public static bool isDead = false;
    public RectTransform pos5;
    private RectTransform enemy_obj = default;
    public GameObject sp_;
    public float speed;
    public static int cnt = 0;

    float timer;
    float setTime;

    void Start()
    {
        timer = 0;
        setTime = 12f;
        enemy_obj = gameObject.GetComponent<RectTransform>();
    }
    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos5.anchoredPosition,Time.deltaTime*speed*70);        
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > setTime)
        {
            sp_.SetActive(true);
            setTime = 99999f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Bullet")
        {
            cnt++;
            if(cnt == 1)
            {
                sp_.SetActive(true);
            }            
            if(cnt == 100)
            {
                Destroy(gameObject);
                GameManager.score_ += 10000;
                isDead = true;
            }
        }
    }  
}
