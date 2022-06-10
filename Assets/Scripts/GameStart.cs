using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public Image fadePanel; //����ȭ���� �� ������Ʈ
    public GameObject gameStartButton; //���ӽ��۹�ư

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
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
