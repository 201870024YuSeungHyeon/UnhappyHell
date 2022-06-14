using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Non_delete : MonoBehaviour
{
    BossStatus bossStatus;
    public AudioSource audioEnemyCollision;
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
            Destroy(collision.gameObject);
            bossStatus.BossHP -= 1;
            Debug.Log(bossStatus.BossHP);
            StartCoroutine(BossHitImage());
            audioEnemyCollision.Play();
        }
    }   

    IEnumerator BossHitImage()
    {
        bossStatus.thisImg.sprite = bossStatus.chage_img_AnubisLow;
        yield return new WaitForSecondsRealtime(0.4f);
        bossStatus.thisImg.sprite = bossStatus.change_img_Nomal;
    }

    
}
