using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScene : MonoBehaviour
{
    public Image fadeInPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeInCoroutine"); //�ڷ�ƾ �Լ� ȣ��
    }

    // Update is called once per frame
    
    IEnumerator FadeInCoroutine() //�г��� ���İ� ���� ( fadeIn ) 
    {
        float fadeCount = 1; //���İ�(����)
        while (fadeCount > 0.0f) //���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeInPanel.color = new Color(0, 0, 0, fadeCount); //���̵��� �ݺ���
        }
        gameObject.SetActive(false);
    }
}
