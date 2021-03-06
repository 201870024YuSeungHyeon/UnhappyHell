using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    public Sprite change_img_Nomal, chage_img_AnubisLow, chage_img_AnubisDead, change_img_AnubisHit; //변경할 이미지 컴포넌트
    public SpriteRenderer thisImg; //오브젝트에 붙어있는 이미지 컴포넌트를 담고있는 변수선언
    public int BossHP; //보스체력
    private float BossHPtime = 90;
   
    void Start()
    {
        thisImg = GetComponent<SpriteRenderer>(); //오브젝트에 부착된 이미지 컴포넌트 가져오기
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
