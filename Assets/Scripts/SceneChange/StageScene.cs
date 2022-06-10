using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageScene : MonoBehaviour
{
    public Image fadeOutPanel; //����ȭ�� ������Ʈ
    public void Button() //��ưŬ���� ȣ��
    {
        fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("Change", 0.3f); //0.3f �� Change����
    }

    public void Change() //�� ��ȯ �Լ�
    {
        SceneManager.LoadScene("LodingScene"); //LodingScene������ ��ȯ
    }
        IEnumerator FadeOutCoroutine()//�г��� ���İ� ���� ( fadeOut )
    {
            float fadeCount = 0; //���İ�(����)
            while (fadeCount < 1.0f)//���İ� ���� �ּ�0 �ִ�1
            {
                fadeCount += 0.10f;
                yield return new WaitForSeconds(0.01f);
                fadeOutPanel.color = new Color(0, 0, 0, fadeCount);//���̵�ƿ� �ݺ���
            }
    }
        
    }
