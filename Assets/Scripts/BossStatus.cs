using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite change_img_Nomal, chage_img_AnubisLow, chage_img_AnubisDead, change_img_AnubisHit; //������ �̹��� ������Ʈ
    public SpriteRenderer thisImg; //������Ʈ�� �پ��ִ� �̹��� ������Ʈ�� ����ִ� ��������
    public int BossHP; //����ü��
    private float BossHPtime = 90;
   
    void Start()
    {
        thisImg = GetComponent<SpriteRenderer>(); //������Ʈ�� ������ �̹��� ������Ʈ ��������
    }

    void Update()
    {
        BossHPtime -= Time.deltaTime;

        if(BossHP <= 0)
        {
            thisImg.sprite = chage_img_AnubisDead;
        }
      

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
