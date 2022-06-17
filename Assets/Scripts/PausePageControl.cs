using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePageControl : MonoBehaviour
{
    public GameObject pausePage;
    public GameObject pausePanel;
    Pause pause;

    void Start()
    {
        pause = FindObjectOfType<Pause>();
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        pause.mainBGM.Play();
        pause.IsPause = false;
        pausePage.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
