using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel; //����ȭ���� �� ������Ʈ(�г�)

    public void Button() //��ư Ŭ���� ȣ��
    {
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
    }
    IEnumerator FadeOutCoroutine() //�г��� ���İ� ���� ( fadeOut )
    {
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f) //���İ� �ּ�0 �ִ�1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount); //���̵�ƿ� �ݺ���
        }
    }
}

