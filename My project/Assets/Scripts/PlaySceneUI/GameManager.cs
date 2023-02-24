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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

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

    void PlayerDie()
    {
        if(PlayerController.isDead == true)
        {
            isGameover = true;
            gameover.SetActive(true);
        }
    }

    void Pause()
    {
        if(SettingBtn.isSetMenuOpen == false)
        {
            isPause =!isPause;
            if(isPause == true){
                Time.timeScale = 0;
                menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;  
                menu.SetActive(false);
            }
        }
    }

    void StageClear()
    {
        if(BossAct.isDead == true)
        {
            stageClear.SetActive(true); 
            if(isPause == false)
            {
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
