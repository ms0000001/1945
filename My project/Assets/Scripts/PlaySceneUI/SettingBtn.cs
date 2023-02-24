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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            setmenu.SetActive(false);
            isSetMenuOpen = false;
        }
    }

    public void OnSettingBtn()
    {
        setmenu.SetActive(true);
        isSetMenuOpen = true;
    }
}
