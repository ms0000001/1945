using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        BackToTitle();
    }

    void BackToTitle()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GFunc.LoadScene(GData.SCENE_NAME_TITLE);
        }
    }
}
