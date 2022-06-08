using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public Vector2 player_Pos;
    Vector2 firstPressPos, secondPressPos, currentSwipe;
    private Rigidbody2D rb;
    bool jumpAllowed =false;
    PlayerHP thePlayerHp;



    // Start is called before the first frame update
    void Start()
    {
        thePlayerHp = FindObjectOfType<PlayerHP>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player_Pos = this.gameObject.transform.position;
        TouchCheck();
    }

    /*void FixedUpdate()
    {
        JumpIfAllowed();


    }*/

    void TouchCheck()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            
            if (t.phase == TouchPhase.Began)
            {
                //첫 번째 터치 지점 저장
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //두 번째 터치 지점 저장
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //첫 번째와 두 번째 지점을 이어서 벡터 생성
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //vector3인것을 vector2로 치환
                currentSwipe.Normalize();

                //위로 슬라이드 했을 때
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                    if (!jumpAllowed)
                    {
                        jumpAllowed = true;
                        rb.AddForce(Vector2.up * jumpForce);



                        //gameObject.GetComponent<BoxCollider2D>().enabled = false;

                        /*if(rb.velocity.y == -809)
                        {
                            gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        }*/

                    }
                    else
                    {
                        return;
                    }
                   
                }
               
                if (currentSwipe.y < 0  &&  currentSwipe.x > -0.5f  && currentSwipe.x < 0.5f )

             {
                    
                    Debug.Log("down swipe");
                }

            }
        }
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
            jumpAllowed = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
           
            if (endTouchPos.y > startTouchPos.y && rb.velocity.y == 0)
            {
                jumpAllowed = true;

            }
        }*/
    }
    /*void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            rb.AddForce(Vector2.up * jumpForce);
            
            
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            /*if(rb.velocity.y == -809)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
        else
        {
            return;
        }
    }*/
       

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
                //collision.transform.parent = transform;
                StartCoroutine(playerHpDelay());
                thePlayerHp.DecreaseHP(1);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Ground"))
            {
                jumpAllowed = false;
            }
        }
    }

    IEnumerator playerHpDelay()
    {
        thePlayerHp.UnColorTransparency();
        yield return new WaitForSecondsRealtime(1f);
        thePlayerHp.ColorTransparency();
    }

}