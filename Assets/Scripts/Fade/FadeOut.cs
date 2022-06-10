using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel; //검은화면이 될 오브젝트(패널)

    public void Button() //버튼 클릭시 호출
    {
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
    }
    IEnumerator FadeOutCoroutine() //패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f) //알파값 최소0 최대1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount); //페이드아웃 반복문
        }
    }
}

