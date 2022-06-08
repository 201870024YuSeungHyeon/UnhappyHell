using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int player_currentHp = 3; //�ִ�ü��, ����ü�� �⺻�� ����
    public GameObject[] hpImage = null;
    PlayerControl playerControl;
    void Start()
    {
        playerControl = GameObject.Find("����back").GetComponent<PlayerControl>();
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos; //ü�¹��� ��ǥ�� ������ ��ǥ�� ��ġ
        if (player_currentHp == 0)
            ExitGame();
    }

    public void DecreaseHP(int p_num) //������ ����� �� ȣ��
    {
        player_currentHp -= p_num;
        SettingHPImage();
    }

    void SettingHPImage() //ü�� ���� �� �����ִ� �̹����ϳ��� ������
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < player_currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
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
