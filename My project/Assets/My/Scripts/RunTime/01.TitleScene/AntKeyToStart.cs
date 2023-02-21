using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntKeyToStart : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Invoke("Delay",3f);
        }
    }

    void Delay()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }
}
