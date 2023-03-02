using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAct : MonoBehaviour
{
    public GameObject mobDie;
    CircleCollider2D circleCollider2D;    
    Image hit;
    Image image;
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
        cnt = 0;
        timer = 0;
        setTime = 12f;
        hit = GetComponent<Image>();
        image = GetComponent<Image>();
        enemy_obj = gameObject.GetComponent<RectTransform>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        isDead = false;
        image.enabled = true;
        circleCollider2D.enabled = true;
    }

    //이동
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

    //피격 시 색상 깜박임
    void Hit()
    {
        hit.color = new Color(1,1,1,1);
    }

    //사망 시
    void BossDestroy()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //{ 피격 시
        if(other.tag == "Bullet")
        {
            cnt++;
            hit.color = new Color(1,0,0,1);
            Invoke("Hit",0.05f);
            if(cnt == 1)
            {
                sp_.SetActive(true);
            }
            //보스 체력            
            if(cnt == 700)
            {
                //사망
                circleCollider2D.enabled = false;
                image.enabled = false;
                mobDie.SetActive(true);
                Invoke("BossDestroy",0.5f);
                GameManager.score_ += 10000;
                isDead = true;
            }
        }
        if(other.tag == "bomb")
        {
            cnt += 40;
            hit.color = new Color(1,0,0,1);
            Invoke("Hit",1.5f);
            //보스 체력
            if(cnt >= 700)
            {
                //사망
                circleCollider2D.enabled = false;
                image.enabled = false;
                mobDie.SetActive(true);
                Invoke("BossDestroy",0.5f);
                GameManager.score_ += 10000;
                isDead = true;
            }
        }
        //} 피격 시
    }  
}
