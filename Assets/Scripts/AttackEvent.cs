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
        
        Debug.Log(Attackmode + "공격모드");
        Debug.Log(r + " r값");
        Debug.Log(g + " r값");
        Debug.Log(b + " r값");

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
                isAbsorb = true;
                Absorbmode = false;
            }
            else
            {
                isAbsorb = false;
                Absorbmode = false;

            }
            if (collision.gameObject.CompareTag("Note_Blue"))
            {
                Destroy(collision.gameObject);
                abc = asbcolor.blue;
                absorption.SetActive(false);
                isAbsorb = true;
            }
            else
            {
                isAbsorb = false;
                Absorbmode = false;
            }

            if (collision.gameObject.CompareTag("Note_Green"))
            {
                Destroy(collision.gameObject);
                abc = asbcolor.green;
                absorption.SetActive(false);
                isAbsorb = true;
            }
            else{
                isAbsorb = false;
                Absorbmode = false;
            }
        }
    }

    public void AbsorbButtonDown()
    {
        if(Attackmode == false) { 
        countTime = 0;
        absorption.SetActive(true);
        Absorbmode = true;
        }
       
        if (Attackmode == true)
        {
            absorption.SetActive(false);
            Debug.Log("공격 발사됨");
            Attackmode = false;
            r = 0;
            g = 0;
            b = 0;
        }
       
        if (Absorbmode == true)
        {
            
            if (isAbsorb == true)
            {

                if (abc == asbcolor.red)
                {
                    r = 1; g = 0; b = 0;
                    if (r == 1)
                    {
                        Attackmode = true;
                        r = 0;
                    }
                }
                if (abc == asbcolor.blue)
                {
                    b = 1; r = 0; g = 0;
                    if (b == 1)
                    {
                        Attackmode = true;
                        b = 0;
                    }
                }
                if (abc == asbcolor.green)
                {
                    g =1; r = 0; b = 0;
                    if (g == 1)
                    {
                        Attackmode = true;
                        g = 0;
                    }
                }


            }

        }
    }

}






