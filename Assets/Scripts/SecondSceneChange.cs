using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondSceneChange : MonoBehaviour
{
    public void Button()
    {
            SceneManager.LoadScene("SampleScene");
    }
}
