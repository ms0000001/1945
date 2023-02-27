using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject playerDie;
    CapsuleCollider2D capsuleCollider2D;
    Image image;

    public GameObject reinforce1;
    public GameObject reinforce2;
    int maxReinforce = 2;
    int curReinforce = 0;

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
        curReinforce = 0;
        bombCnt = 3;
        isDead = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        image = GetComponent<Image>();
        capsuleCollider2D.enabled = true;
        image.enabled = true;
    }

    void Update()
    {
        if(isDead ==false)
        {
            Move();
            AirStrike();
        }
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
             
        if(Boomer.isFlying == false && Time.timeScale == 1)
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

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    public void Die()
    {
        capsuleCollider2D.enabled = false;
        reinforce1.SetActive(false);
        reinforce2.SetActive(false);
        image.enabled = false;
        playerDie.SetActive(true);
        Invoke("Obj_False",0.5f);
        isDead = true;
    }

    void ReinfoeceCnt()
    {
        if(curReinforce > maxReinforce)
        {
            curReinforce = maxReinforce;
        }
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
        if(other.tag == "ItemBullet")
        {
            curReinforce++;
            if(curReinforce == 1)
            {
                reinforce1.SetActive(true);
            }
            if(curReinforce == 2)
            {
                reinforce2.SetActive(true);
            }
        }

        if(other.tag == "Enemy")
            {
                Die();
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
