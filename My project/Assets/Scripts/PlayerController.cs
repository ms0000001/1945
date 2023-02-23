using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject boomer;
    public Image hpbar;
    private Rigidbody2D playerRigidbody;
    public float speed;
    public bool isTouchUp;
    public bool isTouchDown;
    public bool isTouchLeft;
    public bool isTouchRight;
    public static bool isDead;

    public static int bombCnt;
    private int maxBomb = 3;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        bombCnt = 3;
        isDead = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        AirStrike();
    }

    void Move()
    {
        if(GameManager.isPause==false)
        {
            float X = Input.GetAxisRaw("Horizontal");
            if((isTouchLeft && X == -1) || (isTouchRight && X == 1))
            {
                X = 0;
            }
            float Z = Input.GetAxisRaw("Vertical");
            if((isTouchUp && Z == 1) || (isTouchDown && Z == -1))
            {
                Z = 0;
            }
            Vector2 nowP = transform.position;
            Vector2 movP = new Vector2 (X,Z) * speed * Time.deltaTime;

            transform.position = nowP + movP;

            if(Input.GetButtonDown("Horizontal")||
            Input.GetButtonUp("Horizontal"))
            {
                animator.SetInteger("Input",(int)X);
            }
        }
    }

    void AirStrike()
    {
        gameObject.tag = "Player";
        if(Boomer.isFlying == false)
        {
            if(0 < bombCnt && bombCnt <= maxBomb)
            {
                if(Input.GetKeyDown(KeyCode.B))
                {
                    Boomer.isFlying = true;
                    bombCnt--;
                    boomer.SetActive(true);
                }
            }
        }
        if(Boomer.isFlying == true)
        {
            gameObject.tag = "Hide";
        }
        if(bombCnt>maxBomb)
        {
            bombCnt = 3;
        }
    }

    public void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Net"){
            switch(other.gameObject.name)
            {
                case "Up":
                isTouchUp = true;
                break;
                case "Down":
                isTouchDown = true;
                break;
                case "Left":
                isTouchLeft = true;
                break;
                case "Right":
                isTouchRight = true;
                break;
            }
        }
        if(gameObject.tag == "Player")
        {
            if(other.tag == "EnemyBullet")
            {
                hpbar.fillAmount -= 0.1f;
                if(hpbar.fillAmount == 0)
                {
                    Die();
                }
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Net"){
            switch(other.gameObject.name)
            {
                case "Up":
                isTouchUp = false;
                break;
                case "Down":
                isTouchDown = false;
                break;
                case "Left":
                isTouchLeft = false;
                break;
                case "Right":
                isTouchRight = false;
                break;
            }
        }
        
    }
}
