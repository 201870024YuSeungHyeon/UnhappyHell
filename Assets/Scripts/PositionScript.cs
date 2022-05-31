using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    float moveX;
    Rigidbody2D rb;

    [Header("점프 강도")]
    [SerializeField] [Range(100f, 800f)] float jumpForce = 400f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            gameObject.transform.Translate(new Vector3(-4, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            gameObject.transform.Translate(new Vector3(4, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            if(rb.velocity.y == -3.11772)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            gameObject.transform.Translate(new Vector3(0, 0, -1));
        }
    }
}
