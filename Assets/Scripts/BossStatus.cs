using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite chage_img_AnubisLow, chage_img_AnubisDead; //������ �̹��� ������Ʈ
    private Image thisImg; //������Ʈ�� �پ��ִ� �̹��� ������Ʈ�� ����ִ� ��������
    int BossHP = 100; //����ü��

    void Start()
    {
        thisImg = GetComponent<Image>(); //������Ʈ�� ������ �̹��� ������Ʈ ��������
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))  �̰� �׳� Ȯ�ο�...
        {
            BossHP -= 10;
            Debug.Log(BossHP);
            if (BossHP == -10)
                ExitGame();
        }*/
        if ( BossHP <= 0)   //����ü���� 0�̸� AnubisDead�̹����� ����
            thisImg.sprite = chage_img_AnubisDead;
        else if( BossHP <= 40) //����ü���� 40���ϸ� AnubisLow�̹����� ����
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
