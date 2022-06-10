using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int player_currentHp = 3; //����ü�� �⺻�� ����
    public Image[] hpImage = null; //�̹������� �迭������Ʈ
    PlayerControl playerControl; //PlayerControl�������� 
    void Start()
    {
        ColorTransparency();
        playerControl = FindObjectOfType<PlayerControl>(); //PlayerControl�����ϱ�
    }

    void Update()
    {
        transform.localPosition = playerControl.player_Pos; //ü�¹��� ��ǥ�� ������ ��ǥ�� ��ġ
        if (player_currentHp == 0) //ü���� 0�Ǹ� ���� ��
            ExitGame();
    }

    public void DecreaseHP(int p_num) //������������ ȣ��
    {
        player_currentHp -= p_num; //�Ķ���� ����ŭ ü�°���
        SettingHPImage();
    }

    void SettingHPImage() //ü�� ���ҽ� ü���̹��� �� ���� ��Ȱ��ȭ
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < player_currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }

    public void ColorTransparency() //ü�¹� ���� 0
    {
        for (int i = 0; i < hpImage.Length; i++) 
        {
            Color color = hpImage[i].color;
            color.a = 0.0f;
            hpImage[i].color = color;
        }
    }

    public void UnColorTransparency() //ü�¹� ���� 100
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
