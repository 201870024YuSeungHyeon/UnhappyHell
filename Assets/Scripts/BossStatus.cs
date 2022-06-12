using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite chage_img_AnubisLow, chage_img_AnubisDead; //변경할 이미지 컴포넌트
    private Image thisImg; //오브젝트에 붙어있는 이미지 컴포넌트를 담고있는 변수선언
    public int BossHP = 15; //보스체력

    void Start()
    {
        thisImg = GetComponent<Image>(); //오브젝트에 부착된 이미지 컴포넌트 가져오기
    }

    void Update()
    {
        if ( BossHP <= 0)   //보스체력이 0이면 AnubisDead이미지로 변경
            thisImg.sprite = chage_img_AnubisDead;
        else if(BossHP <= 14) //보스체력이 40이하면 AnubisLow이미지로 변경
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
