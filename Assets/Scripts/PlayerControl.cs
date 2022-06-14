using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public Vector2 player_Pos;
    public AudioSource audioEnemyCollision;

    public Sprite Change_GanglimAtk, Change_Ganglin_Idle;
    public SpriteRenderer ganglimAtk;
    

    private Rigidbody2D rb;
   
    bool jumpAllowed =false;
   
    PlayerHP thePlayerHp; //PlayerHp참조 변수
   
    GameObject jumpBtn;
    GameObject LeftBtn;
    GameObject RightBtn;


    private float fDestroyTime = 3f;
    private float fTickTime;

    AttackEvent ae;


    bool isHurt;
    SpriteRenderer sr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);

    /*public Sprite playeratk;
    Image playerImg;*/
   

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ganglimAtk = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        jumpBtn = GameObject.Find("JumpButton");
        LeftBtn = GameObject.Find("LButton");
        RightBtn = GameObject.Find("RButton");
        thePlayerHp = FindObjectOfType<PlayerHP>(); //PlayerHP 참조
        ae = FindObjectOfType<AttackEvent>();

        //playerImg = GetComponent<Image>();

    }

    void Update()
    {
        /*if(ae.absorption.activeSelf == false)
        {
            playerImg.sprite = playeratk;
        }*/


        fTickTime += Time.deltaTime;
        if (thePlayerHp.player_currentHp != thePlayerHp.player_MaxHp)
        {
            if (fTickTime >= fDestroyTime)
            {
                StartCoroutine(playerHpDelay());
                thePlayerHp.IncreaseHP(1);
                fTickTime = 0f;
            }
        }

        player_Pos = gameObject.transform.position; //캐릭터 위치값을 변수에 저장
        
        if (jumpAllowed == true)
        {
            jumpBtn.SetActive(false);
        }
        if (jumpAllowed == false)
        {
            jumpBtn.SetActive(true);
        }
    }
    
    public void JumpTouched()
    {
        if (!jumpAllowed)
        {
            jumpAllowed = true;
            rb.AddForce(Vector2.up * jumpForce);
            gameObject.layer = 7;
        }
        else
        {
            return;
        } 
    }

    public void LButtonDown()
    {
        
        
        if(gameObject.transform.position.x != 131)
        {
            transform.Translate(-200, 10, 0);
        }
        else if(gameObject.transform.position.x > 131)
        {
            transform.Translate(0, 10, 0);
        }
        
    }
    public void RButtonDown()
    {
        
        if(gameObject.transform.position.x != 931)
        {
            transform.Translate(200, 10, 0);
        }
        else if(gameObject.transform.position.x < 931)
        {
            transform.Translate(0, 10, 0);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.CompareTag("Note_JumpX") || collision.CompareTag("Note_Blue") || collision.CompareTag("Note_Red") || collision.CompareTag("Note_Green"))
            {
                Hurt();
                StartCoroutine(HurtRoutine());
                StartCoroutine(alphaBlink());
                StartCoroutine(playerHpDelay());

                Destroy(collision.gameObject);
                audioEnemyCollision.Play();
            }
            if (collision.gameObject.CompareTag("Ground"))
            {
                gameObject.layer = 12;
                jumpAllowed = false;
            }
        }

    }

    public void Hurt()
    {
        if (!isHurt)
        {
            isHurt = true;
            thePlayerHp.DecreaseHP(1);
            fTickTime = 0.0f;
        }

    }

    IEnumerator playerHpDelay() //체력바 1초동안 활성화
    {
        thePlayerHp.UnColorTransparency();
        yield return new WaitForSecondsRealtime(1f);
        thePlayerHp.ColorTransparency();
    }

    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(1f);
        isHurt = false;
    }

    IEnumerator alphaBlink()
    {
        sr.color = halfA;
        yield return new WaitForSeconds(0.2f);
        sr.color = fullA;
        yield return new WaitForSeconds(0.2f);
        sr.color = halfA;
        yield return new WaitForSeconds(0.2f);
        sr.color = fullA;
        yield return new WaitForSeconds(0.2f);
        sr.color = halfA;
        yield return new WaitForSeconds(0.2f);
        sr.color = fullA;
    }
}