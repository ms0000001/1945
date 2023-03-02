using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Stage1 : MonoBehaviour
{
    public GameObject clearBGM;
    public GameObject bossBGM;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public static AudioSource BGM;
    bool isMute = false;

    void Start() 
    {
        BGM = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        //보스 출현 배경음 재생
        if(Enemy3.isDead == true)
        {
            BGM.Stop();
            bossBGM.SetActive(true);
        }
        //클리어 배경음 재생
        if(BossAct.isDead == true)
        {
            bossBGM.SetActive(false);
            Invoke("clearDelay",0.7f);
        }
    }

    void clearDelay()
    {
        clearBGM.SetActive(true);
    }

    //{ 음량 조절
    public void OnPlusBtn()
    {
        //볼륨 +
        BGM.volume += 0.3f;
        if(BGM.volume == 1)
        {
            bar3.SetActive(true);
        }
        if(BGM.volume >= 0.7f)
        {
            bar2.SetActive(true);
        }
        if(BGM.volume >= 0.3f)
        {
            bar1.SetActive(true);
        }
    }

    public void OnMinusBtn()
    {
        //볼륨 -
        BGM.volume -= 0.3f;
        if(BGM.volume < 1)
        {
            bar3.SetActive(false);
        }
        if(0.3f <= BGM.volume && BGM.volume < 0.7f)
        {
            bar2.SetActive(false);
        }
        if(BGM.volume < 0.3f)
        {
            bar1.SetActive(false);
        }
    }

    public void OnMute()
    {
        //음소거
        isMute =! isMute;

        if(isMute == true)
        {
            BGM.volume = 0;
            bar3.SetActive(false);
            bar2.SetActive(false);
            bar1.SetActive(false);
        }
        else
        {
            BGM.volume = 1;
            bar3.SetActive(true);
            bar2.SetActive(true);
            bar1.SetActive(true);
        }
    }
    //} 음량 조절
}
