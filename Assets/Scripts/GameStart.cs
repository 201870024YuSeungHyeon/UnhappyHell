using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public Image fadePanel; //검은화면이 될 오브젝트
    public GameObject gameStartButton; //게임시작버튼

    public void Button()
    {
        Debug.Log("click");
        fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine());
        Invoke("Change", 1f);
    }

    public void Change()
    {
        SceneManager.LoadScene("StageScene");
    }

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
