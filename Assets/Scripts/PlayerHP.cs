using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    int Player_maxHp = 3, Player_currentHp = 3; //�ִ�ü��, ����ü�� �⺻�� ����
    public GameObject[] hpImage = null;
   

    void Update()
    {
  //      hpImage.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
 
   
       
    }

    public void DecreaseHP(int p_num) //������ ����� �� ȣ��
    {
        Player_currentHp -= p_num;

        if(Player_currentHp <= 0)
        {
            //Debug.Log("ı");
        }

        SettingHPImage();
    }

    void SettingHPImage() //ü�� ���� �� �����ִ� �̹����ϳ��� ������
    {
        for ( int i = 0; i < hpImage.Length; i++)
        {
            if (i < Player_currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }
}
