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
        if(Enemy3.isDead == true)
        {
            BGM.Stop();
            bossBGM.SetActive(true);
        }
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

    public void OnPlusBtn()
    {
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
}
