using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Note_Non_delete : MonoBehaviour
{
    BossStatus bossStatus;
    public AudioSource audioEnemyCollision;
    public AudioSource boss_Dead;
    // Start is called before the first frame update
    void Start()
    {
        bossStatus = FindObjectOfType<BossStatus>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Attack"))
        {
            if (bossStatus.BossHP >= 4)
            {
                Destroy(collision.gameObject);
                bossStatus.BossHP -= 1;
                Debug.Log(bossStatus.BossHP);
                StartCoroutine(BossHitImage());

                if (bossStatus.BossHP != 0)
                    audioEnemyCollision.Play();
                else
                    boss_Dead.Play();

            }

            else if (bossStatus.BossHP <= 3)
            {
                bossStatus.thisImg.sprite = bossStatus.chage_img_AnubisLow;
                Destroy(collision.gameObject);
                bossStatus.BossHP -= 1;
                Debug.Log(bossStatus.BossHP);

                //StopCoroutine(BossHitImage());

                StartCoroutine(BossHitImageLow());

                if (bossStatus.BossHP != 0)
                    audioEnemyCollision.Play();
                else
                    boss_Dead.Play();
            }
            if (bossStatus.BossHP == 0)
            {
                StopCoroutine(BossHitImage());
                StopCoroutine(BossHitImageLow());
                bossStatus.thisImg.sprite = bossStatus.chage_img_AnubisDead;
                Invoke("Change", 1.5f);
                
                if (bossStatus.BossHP != 0)
                    audioEnemyCollision.Play();
                else
                {
                    boss_Dead.Play();
                   
                }               
            }
        }
    }

    public void Change() //¾À ÀüÈ¯
    {
        SceneManager.LoadScene("ClearScene");
    }


    IEnumerator BossHitImage()
    {
        bossStatus.thisImg.sprite = bossStatus.change_img_AnubisHit;
        yield return new WaitForSecondsRealtime(0.4f);
        bossStatus.thisImg.sprite = bossStatus.change_img_Nomal;
    }
    IEnumerator BossHitImageLow()
    {
        bossStatus.thisImg.sprite = bossStatus.change_img_AnubisHit;
        yield return new WaitForSecondsRealtime(0.4f);
        bossStatus.thisImg.sprite = bossStatus.chage_img_AnubisLow;
    }


}
