using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageScene : MonoBehaviour
{
    public Image fadeOutPanel; //검은화면 컴포넌트
    public void Button() //버튼클릭시 호출
    {
        fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("Change", 0.3f); //0.3f 후 Change실행
    }

    public void Change() //씬 전환 함수
    {
        SceneManager.LoadScene("LodingScene"); //LodingScene씬으로 전환
    }
        IEnumerator FadeOutCoroutine()//패널의 알파값 조절 ( fadeOut )
    {
            float fadeCount = 0; //알파값(투명도)
            while (fadeCount < 1.0f)//알파값 변경 최소0 최대1
            {
                fadeCount += 0.10f;
                yield return new WaitForSeconds(0.01f);
                fadeOutPanel.color = new Color(0, 0, 0, fadeCount);//페이드아웃 반복문
            }
    }
        
    }
