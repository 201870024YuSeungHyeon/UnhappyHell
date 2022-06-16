using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public AudioSource mainBGM;
    bool IsPause;

    void Start()
    {
        mainBGM.Play();
        IsPause = false;
    }

    public void PauseButtonDown()
    {
        if ( IsPause == false )
        {
            Time.timeScale = 0;
            mainBGM.Pause();
            IsPause = true;
        }
        else
        {
            Time.timeScale = 1;
            mainBGM.Play();
            IsPause = false;
        }
    }
}
