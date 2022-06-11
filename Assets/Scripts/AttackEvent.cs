using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public GameObject absorption;
    public GameObject absorbBtn;
    PlayerControl playerControl;


    public bool isAbsorb;
    public bool Absorbmode;
    public bool Attackmode;

    enum asbcolor { red, blue, green }
    asbcolor abc;
    
    int r = 0, g = 0, b = 0;

    private float absorbTime = 0.1f;
    private float countTime;


    // Start is called before the first frame update
    void Start()
    {
        absorption = GameObject.Find("Absorption");
        absorbBtn = GameObject.Find("AbsorbButton");
        absorption.SetActive(false);
        playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = playerControl.player_Pos + new Vector2(0,200);
        countTime += Time.deltaTime;
        //Debug.Log(r + " " + g + " " + b);
      
        if (countTime >= absorbTime)
        {
            absorption.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Note_Red"))
            {
                Destroy(collision.gameObject);
                abc = asbcolor.red;
                absorption.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Note_Blue"))
            {
                Destroy(collision.gameObject);
                abc = asbcolor.blue;
                absorption.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Note_Green"))
            {
                Destroy(collision.gameObject);
                abc = asbcolor.green;
                absorption.SetActive(false);
            }
        }
    }

    public void AbsorbButtonDown()
    {
        countTime = 0;
        absorption.SetActive(true);
       
        if (!Absorbmode)
        {
            Absorbmode = true;
            if (isAbsorb)
            {

                if (abc == asbcolor.red)
                {
                    r++; g = 0; b = 0;
                    if (r == 2)
                    {
                        Attackmode = true;
                        r = 0;
                    }
                }
                if (abc == asbcolor.blue)
                {
                    b++; r = 0; g = 0;
                    if (b == 2)
                    {
                        Attackmode = true;
                        b = 0;
                    }
                }
                if (abc == asbcolor.green)
                {
                    g++; r = 0; b = 0;
                    if (g == 2)
                    {
                        Attackmode = true;
                        g = 0;
                    }
                }


            }

        }
    }
}






