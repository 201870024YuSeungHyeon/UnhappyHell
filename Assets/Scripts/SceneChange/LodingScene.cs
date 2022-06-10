using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingScene : MonoBehaviour //LodingScene->fade�� ����
{
    public Image fadePanel; //����ȭ�� ������Ʈ

    public void Button() //��ư Ŭ�� �� ȣ��
    {
        fadePanel.gameObject.SetActive(true);//�г� Ȱ��ȭ
        StartCoroutine("FadeCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("Change", 0.3f); //0.3f �� Change����
    }

    public void Change() //�� ��ȯ �Լ�
    {
        SceneManager.LoadScene("InGameScene"); //InGameScene����
    }

    IEnumerator FadeCoroutine()//�г��� ���İ� ���� ( fadeOut )
    {
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f) //���İ� �ּ�0 �ִ�1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);//���̵�ƿ� �ݺ���
        }
    }
}
