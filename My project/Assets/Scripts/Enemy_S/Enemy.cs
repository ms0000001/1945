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
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
            isDead = true;
        }
        if(other.tag == "bomb")
        {
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
            Invoke("Obj_False",0.5f);
            GameManager.score_ += 400;
            isDead = true;
        }
        if(other.tag == "Player")
        {
            boxCollider2D.enabled = false;
            image.enabled = false;
            mobDie.SetActive(true);
            playerAudio.Play();
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
