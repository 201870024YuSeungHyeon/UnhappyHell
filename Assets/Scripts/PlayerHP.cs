using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int player_currentHp = 3; //현재체력 기본값 설정
    public Image[] hpImage = null; //이미지참조 배열컴포넌트
    PlayerControl playerControl; //PlayerControl참조변수 
    void Start()
    {
        ColorTransparency();
        playerControl = FindObjectOfType<PlayerControl>(); //PlayerControl참조하기
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos; //체력바의 좌표와 강림의 좌표값 일치
        if (player_currentHp == 0) //체력이 0되면 게임 끝
            ExitGame();
    }

    public void DecreaseHP(int p_num) //데미지입을때 호출
    {
        player_currentHp -= p_num; //파라미터 값만큼 체력감소
        SettingHPImage();
    }

    void SettingHPImage() //체력 감소시 체력이미지 한 개씩 비활성화
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < player_currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }

    public void ColorTransparency() //체력바 투명도 0
    {
        for (int i = 0; i < hpImage.Length; i++) 
        {
            Color color = hpImage[i].color;
            color.a = 0.0f;
            hpImage[i].color = color;
        }
    }

    public void UnColorTransparency() //체력바 투명도 100
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            Color color = hpImage[i].color;
            color.a = 1.0f;
            hpImage[i].color = color;
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
