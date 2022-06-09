using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScene : MonoBehaviour
{
    public void Button()
    {
        SceneManager.LoadScene("LodingScene");
    }
}
