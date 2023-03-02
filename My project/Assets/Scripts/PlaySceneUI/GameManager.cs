using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameover;
    public GameObject stageClear;
    public Text scoreText;

    public static bool isPause = false;
    public static bool isGameover;
    public static int score_;
    
    void Start()
    {
        isPause = false;
        isGameover = false;
        score_ = 0;
    }

    void Update()
    {
        Score();
        PlayerDie();
        StageClear();
        //키 입력 시 일시정지
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    //점수 표시
    void Score()
    {        
        if(!isGameover)
        {
            scoreText.text = "Score : " + score_;
        }
        else
        {
            if(!isPause)
            {
                if(Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("02.PlayScene");
                }
            }
        }
    }

    //플레이어 사망 시 게임오버 표시
    void PlayerDie()
    {
        if(PlayerController.isDead == true)
        {
            isGameover = true;
            gameover.SetActive(true);
        }
    }


    //일시정지
    void Pause()
    {
        if(SettingBtn.isSetMenuOpen == false)
        {
            isPause =!isPause;
            if(isPause == true){
                Time.timeScale = 0;
                //메뉴 열림
                menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1; 
                //메뉴 닫힘 
                menu.SetActive(false);
            }
        }
    }

    //스테이지 클리어 시
    void StageClear()
    {
        //클리어 조건
        if(BossAct.isDead == true)
        {
            //클리어 UI 활성화
            stageClear.SetActive(true); 
            if(isPause == false)
            {
                //키 입력 시 타이틀로 이동
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    stageClear.SetActive(false);  
                    BossAct.isDead = false;
                    GFunc.LoadScene(GData.SCENE_NAME_TITLE);
                }
            } 
        }
    }
}
