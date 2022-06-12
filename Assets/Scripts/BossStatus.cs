using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite chage_img_AnubisLow, chage_img_AnubisDead; //������ �̹��� ������Ʈ
    private SpriteRenderer thisImg; //������Ʈ�� �پ��ִ� �̹��� ������Ʈ�� ����ִ� ��������
    public int BossHP = 15; //����ü��

    void Start()
    {
        thisImg = GetComponent<SpriteRenderer>(); //������Ʈ�� ������ �̹��� ������Ʈ ��������
    }

    void Update()
    {
        if (BossHP <= 0) //����ü���� 0�̸� AnubisDead�̹����� ����
        {
            thisImg.sprite = chage_img_AnubisDead;
            ExitGame();
        }
        else if (BossHP <= 7) //����ü���� 7���ϸ� AnubisLow�̹����� ����
            thisImg.sprite = chage_img_AnubisLow;
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
