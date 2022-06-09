using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LodingScene : MonoBehaviour
{
    public void Button()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
