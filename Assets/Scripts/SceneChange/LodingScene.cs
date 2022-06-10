using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingScene : MonoBehaviour //LodingScene->fade에 적용
{
    public Image fadePanel; //검은화면 오브젝트

    public void Button() //버튼 클릭 시 호출
    {
        fadePanel.gameObject.SetActive(true);//패널 활성화
        StartCoroutine("FadeCoroutine"); //코루틴 함수 호출
        Invoke("Change", 0.3f); //0.3f 후 Change실행
    }

    public void Change() //씬 전환 함수
    {
        SceneManager.LoadScene("InGameScene"); //InGameScene으로
    }

    IEnumerator FadeCoroutine()//패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f) //알파값 최소0 최대1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);//페이드아웃 반복문
        }
    }
}
