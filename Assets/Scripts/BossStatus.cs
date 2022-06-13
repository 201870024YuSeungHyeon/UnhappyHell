using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite chage_img_AnubisLow, chage_img_AnubisDead; //������ �̹��� ������Ʈ
    private SpriteRenderer thisImg; //������Ʈ�� �پ��ִ� �̹��� ������Ʈ�� ����ִ� ��������
    public int BossHP = 5; //����ü��
    private float BossHPtime = 90;
   
    void Start()
    {
        thisImg = GetComponent<SpriteRenderer>(); //������Ʈ�� ������ �̹��� ������Ʈ ��������
    }

    void Update()
    {
        BossHPtime -= Time.deltaTime;
        Debug.Log(BossHPtime);
       
        if (BossHP <= 0) //����ü���� 0�̸� AnubisDead�̹����� ����
        {
            thisImg.sprite = chage_img_AnubisDead;
            ExitGame();
        }
        else if (BossHP <= 2) //����ü���� 7���ϸ� AnubisLow�̹����� ����
            thisImg.sprite = chage_img_AnubisLow;

        if(BossHPtime<= 0)
        {
            thisImg.sprite = chage_img_AnubisDead;
        }
        else if(BossHPtime <= 45)
        {
            thisImg.sprite = chage_img_AnubisLow;
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
