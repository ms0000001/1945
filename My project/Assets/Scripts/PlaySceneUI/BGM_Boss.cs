using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Boss : MonoBehaviour
{
    AudioSource bossBGM;

    void Start()
    {
        bossBGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        bossBGM.volume = BGM_Stage1.BGM.volume;
    }
}
