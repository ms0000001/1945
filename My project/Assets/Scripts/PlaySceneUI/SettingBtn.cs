using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn : MonoBehaviour
{
    public GameObject setmenu;
    public static bool isSetMenuOpen;
    void Start()
    {
        isSetMenuOpen = false;
    }

    void Update()
    {
        //키 입력 시 세팅창 비활성화
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            setmenu.SetActive(false);
            isSetMenuOpen = false;
        }
    }

    //세팅버튼 클릭 시 창 활성화
    public void OnSettingBtn()
    {
        setmenu.SetActive(true);
        isSetMenuOpen = true;
    }
}
