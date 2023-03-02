using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    AudioSource playerAudio;

    BoxCollider2D boxCollider2D;
    Image image;
    public GameObject mobDie;
    public RectTransform pos1;
    private RectTransform enemy_obj = default;
    public float speed;
    public static bool isDead = false;

    void Start()
    {
        isDead = false;
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
            pos1.anchoredPosition,Time.deltaTime*speed*80);
    }    

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //피격 시
        if(other.tag == "Bullet")
        {
            isDead = true;
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
        }
        if(other.tag == "bomb")
        {
            isDead = true;
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
        }
        //플레이어와 충돌 시
        if(other.tag == "Player")
        {
            isDead = true;
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
        }
        //맵 밖으로 이동 시
        if(other.tag == "EnemyNet")
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }    
}
