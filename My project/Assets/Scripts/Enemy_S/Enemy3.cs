using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour
{
    AudioSource playerAudio;

    BoxCollider2D boxCollider2D;
    Image image;
    public GameObject mobDie;
    Image hit;
    public RectTransform dropPos;
    public RectTransform parents;
    public GameObject Item_Bomb;
    public GameObject Item_Medal;
    public GameObject Item_Bullet;
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
        playerAudio = GetComponent<AudioSource>();
        boxCollider2D.enabled = true;
        image.enabled = true;
    }

    //적 이동
    private void FixedUpdate() {
        enemy_obj.anchoredPosition = Vector3.MoveTowards(
            enemy_obj.anchoredPosition,
            pos3.anchoredPosition,Time.deltaTime*speed*80);        
        
    }

    void Update()
    {
        ShootPointOn();
    }

    //피격 시 사격 시작
    void ShootPointOn()
    {
        if(cnt > 0)
        {
            shoot_P.SetActive(true);
        }
        //사망 시 비활성화
        if(isDead == true)
        {
            shoot_P.SetActive(false);
        }
    }

    //피격 시 색상 깜박임
    void Hit()
    {
        hit.color = new Color(1,1,1,1);
    }

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    //{ 사망 시 랜덤 아이템 드롭
    void CreateItem()
    {
        int randomItem = Random.Range(1,4);
        switch(randomItem)
        {
            case 1:
            GameObject inst1 = Instantiate(Item_Bullet,dropPos);
            inst1.transform.SetParent(parents.transform.parent);
            break;
            case 2:
            GameObject inst2 = Instantiate(Item_Medal,dropPos);
            inst2.transform.SetParent(parents.transform.parent);
            break;
            case 3:
            GameObject inst3 = Instantiate(Item_Bomb,dropPos);
            inst3.transform.SetParent(parents.transform.parent);
            break;
        }
    }
    //} 사망 시 랜덤 아이템 드롭

    private void OnTriggerEnter2D(Collider2D other) {
        //피격 시
        if(other.tag == "Bullet")
        {
            cnt++;
            hit.color = new Color(1,0,0,1);
            Invoke("Hit",0.05f);   
            if(cnt == 10)
            {
                isDead = true;
                boxCollider2D.enabled = false;
                image.enabled = false;
                mobDie.SetActive(true);
                CreateItem();
                playerAudio.Play();
                Invoke("Obj_False",0.5f);
                GameManager.score_ += 1000;
            }
        }
        if(other.tag == "bomb")
        {
            isDead = true;
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            CreateItem();
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 1000;
        }
        //플레이어와 충돌 시
        if(other.tag == "Player")
        {
            isDead = true;
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            CreateItem();
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 1000;
        }
    }
}
