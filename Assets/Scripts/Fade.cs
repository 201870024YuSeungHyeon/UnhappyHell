using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadePanel; //����ȭ���� �� ������Ʈ
    public GameObject gameStartButton; //���ӽ��۹�ư

    void Start()
    {
        fadePanel.gameObject.SetActive(false);
    }
    public void FadeButton()
    {
        Debug.Log("click");
        fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine());
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

