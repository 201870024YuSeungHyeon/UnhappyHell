using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public AudioSource mainBGM;
    public GameObject pausePage;
    public GameObject pausePanel;
    public bool IsPause;

    void Start()
    {
        mainBGM.Play();
        IsPause = false;
        pausePage.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void PauseButtonDown()
    {
        Time.timeScale = 0;
        mainBGM.Pause();
        pausePage.SetActive(true);
        pausePanel.SetActive(true);
        IsPause = true;
    }
}
