using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public Vector2 player_Pos;
    //Vector2 firstPressPos, secondPressPos, currentSwipe;
   
    private Rigidbody2D rb;
   
    bool jumpAllowed =false;
   
    PlayerHP thePlayerHp;
    public GameObject absorption;

    public bool isAbsorb;

    bool isHurt;
    SpriteRenderer sr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        thePlayerHp = FindObjectOfType<PlayerHP>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player_Pos = this.gameObject.transform.position;   
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
        transform.Translate(-200, 10, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(200, 10, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Note"))
            {
                Hurt();
                StartCoroutine(HurtRoutine());
                StartCoroutine(alphaBlink());
                StartCoroutine(playerHpDelay());

                Destroy(collision.gameObject);
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
        }
    }

    IEnumerator playerHpDelay()
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
        yield return new WaitForSeconds(0.25f);
        sr.color = fullA;
        yield return new WaitForSeconds(0.25f);
        sr.color = halfA;
        yield return new WaitForSeconds(0.25f);
        sr.color = fullA;
        yield return new WaitForSeconds(0.25f);
        sr.color = halfA;
        yield return new WaitForSeconds(0.25f);
        sr.color = fullA;
    }
}