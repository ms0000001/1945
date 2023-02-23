using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameover;
    public GameObject pauseMenu;
    public Text scoreText;

    public static bool isPause = false;
    public static bool isGameover;
    public static int score_;
    void Start()
    {
        isGameover = false;
        score_ = 0;
    }

    void Update()
    {
        Score();
        PlayerDie();
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
        isPause =!isPause;
        if(isPause == true){
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;  

    }
}
