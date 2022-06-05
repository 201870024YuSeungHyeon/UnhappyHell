using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 600f;
    Vector2 startTouchPos, endTouchPos;
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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if (endTouchPos.y > startTouchPos.y && rb.velocity.y == 0)
            {
                jumpAllowed = true;

            }
        }
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
        transform.Translate(-1.17f, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(1.17f, 0, 0);
    }
}