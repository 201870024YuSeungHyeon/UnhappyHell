using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    bool gameStartButton = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { gameStartButton = true; }
    }
    public void Button()
    {
            SceneManager.LoadScene("StageScene");
    }
}
