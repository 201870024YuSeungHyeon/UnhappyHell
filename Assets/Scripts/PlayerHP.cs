using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int Player_currentHp = 3; //�ִ�ü��, ����ü�� �⺻�� ����
    public GameObject[] hpImage = null;
    PlayerControl playerControl;
    void Start()
    {
        playerControl = GameObject.Find("����back").GetComponent<PlayerControl>();
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos; //ü�¹��� ��ǥ�� ������ ��ǥ�� ��ġ
    }

    public void DecreaseHP(int p_num) //������ ����� �� ȣ��
    {
        Player_currentHp -= p_num;

        if (Player_currentHp <= 0)
        {
            //Debug.Log("ı");
        }

        SettingHPImage();
    }

    void SettingHPImage() //ü�� ���� �� �����ִ� �̹����ϳ��� ������
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
