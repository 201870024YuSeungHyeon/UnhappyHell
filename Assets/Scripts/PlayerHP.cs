using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int Player_currentHp = 3; //최대체력, 현재체력 기본값 설정
    public GameObject[] hpImage = null;
    PlayerControl playerControl;
    void Start()
    {
        playerControl = GameObject.Find("강림back").GetComponent<PlayerControl>();
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos; //체력바의 좌표와 강림의 좌표값 일치
    }

    public void DecreaseHP(int p_num) //데미지 닳았을 때 호출
    {
        Player_currentHp -= p_num;

        if (Player_currentHp <= 0)
        {
            //Debug.Log("캇");
        }

        SettingHPImage();
    }

    void SettingHPImage() //체력 닳을 시 보여주는 이미지하나씩 없애줌
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < Player_currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }
}
