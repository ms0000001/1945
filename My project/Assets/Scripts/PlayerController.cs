using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSource playerAudio;

    public GameObject playerDie;
    CapsuleCollider2D capsuleCollider2D;
    Image image;

    public GameObject reinforce1;
    public GameObject reinforce2;
    int maxReinforce = 2;
    int curReinforce = 0;
    bool debugMode = false;

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
        debugMode = false;
        curReinforce = 0;
        bombCnt = 3;
        isDead = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        playerAudio = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        capsuleCollider2D.enabled = true;
        image.enabled = true;
    }

    void Update()
    {
        //{ 플레이어 사망 시 조작 불가
        if(isDead ==false)
        {
            Move();
            AirStrike();
            DebugMode();
        }
        //} 플레이어 사망 시 조작 불가
    }

    //{ 플레이어 이동
    void Move()
    {
        //일시정지 시 조작 불가
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

            //방향키 좌우 입력 값에 따라 애니메이션 재생
            if(Input.GetButtonDown("Horizontal")||
            Input.GetButtonUp("Horizontal"))
            {
                animator.SetInteger("Input",(int)X);
            }
        }
    }
    //} 플레이어 이동

    //{ 폭탄 사용
    void AirStrike()
    {
        //폭탄 사용 후 플레이어 태그변경
        gameObject.tag = "Player";

        //폭탄 사용 중, 일시정지 상태일 때 사용 불가     
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
        //폭탄 사용 중 무적 판정
        if(Boomer.isFlying == true)
        {
            gameObject.tag = "Hide";
        }
        //최대 폭탄 개수 이상 획득 시
        if(bombCnt>maxBomb)
        {
            bombCnt = 3;
        }
    }
    //} 폭탄 사용

    void Obj_False()
    {
        gameObject.SetActive(false);
    }

    //{ 플레이어 사망
    public void Die()
    {
        if(debugMode == false)
        {
            //강화 비활성화
            reinforce1.SetActive(false);
            reinforce2.SetActive(false);

            //충돌, 이미지 비활성화
            capsuleCollider2D.enabled = false;
            image.enabled = false;

            //사망 애니메이션
            playerDie.SetActive(true);

            //사망 사운드
            playerAudio.Play();

            //오브젝트 비활성화
            Invoke("Obj_False",0.5f);
            isDead = true;
        }
    }
    //} 플레이어 사망

    //최대 강화 횟수
    void ReinfoeceCnt()
    {
        if(curReinforce > maxReinforce)
        {
            curReinforce = maxReinforce;
        }
    }

    //디버그 모드 실행
    void DebugMode()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            debugMode = true;          
            reinforce1.SetActive(true);
            reinforce2.SetActive(true);
            maxBomb = 999;
            bombCnt = 999;  
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //화면 경계 충돌 확인
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

        //{ 총알 피격 시
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
        //} 총알 피격 시
        
        //{ 강화 아이템 획득 시
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
        //} 강화 아이템 획득 시

        //적과 충돌 시
        if(other.tag == "Enemy")
            {
                Die();
            }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //화면 경계 충돌 확인        
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
