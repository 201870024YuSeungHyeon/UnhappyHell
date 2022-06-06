using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 600f;
    Vector2 firstPressPos, secondPressPos, currentSwipe;
    private Rigidbody2D rb;
    bool jumpAllowed = false;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchCheck();
    }

    void FixedUpdate()
    {
        JumpIfAllowed();


    }

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
                if (currentSwipe.y > 0  && currentSwipe.x > -0.3f && currentSwipe.x < 0.3f && rb.velocity.y == 0)
             {
                    
                    jumpAllowed = true;
                }
                if (currentSwipe.y < 0  &&  currentSwipe.x > -0.5f  && currentSwipe.x < 0.5f && rb.velocity.y == 150.1405)
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
    void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumpAllowed = false;
        }
    }

    public void LButtonDown()
    {
        transform.Translate(-200, 0, 0);
        

    }
    public void RButtonDown()
    {
        transform.Translate(200, 0, 0);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Note"))
            {
                collision.transform.parent = transform;
                Debug.Log("Hit");
                Destroy(collision.gameObject);
            }
        }
    }
  

}