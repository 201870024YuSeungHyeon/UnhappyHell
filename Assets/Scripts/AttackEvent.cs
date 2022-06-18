using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public GameObject absorption;
    public GameObject absorbBtn;
    public SpriteRenderer absorptionSprite;
    public AudioSource swordsound;

    public bool isAbsorb;
    public bool Absorbmode;
    public bool Attackmode;
   

    enum asbcolor {normal, red, blue, green }
    public enum beadB {normal, red, blue, green}

    public beadB bead;
    asbcolor abc;
    
    public int r = 0, g = 0, b = 0;

    private float absorbTime = 0.1f;
    private float countTime;

    PlayerControl playerControl;
    
    // Start is called before the first frame update
    void Start()
    {
        absorption = GameObject.Find("Absorption");
        absorptionSprite = GetComponent<SpriteRenderer>();
        absorbBtn = GameObject.Find("AbsorbButton");
       
        playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = playerControl.player_Pos + new Vector2(0,200);

       

      
        countTime += Time.deltaTime;
        
       if (countTime >= absorbTime)
        {
            BarrierColorTransparency();
            playerControl.ganglimAtk.sprite = playerControl.Change_Ganglin_Idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (abc ==asbcolor.normal)
            {
                bead = beadB.normal;
                if (collision.gameObject.CompareTag("Note_Red") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    abc = asbcolor.red;
                    BarrierColorTransparency();
                    isAbsorb = true;
                    Absorbmode = false;
                    

                }
                if (collision.gameObject.CompareTag("Note_Blue") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    abc = asbcolor.blue;
                    BarrierColorTransparency();
                    isAbsorb = true;
                    Absorbmode = false;


                }
                if (collision.gameObject.CompareTag("Note_Green") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    abc = asbcolor.green;
                    BarrierColorTransparency();
                    isAbsorb = true;
                    Absorbmode = false;

                }
            }
            if (abc == asbcolor.red)
            {
                bead = beadB.red;
                if (abc == asbcolor.red && collision.gameObject.CompareTag("Note_Red") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = true;
                    Debug.Log("공격모드 활성화");
                    swordsound.Play();
                    abc = asbcolor.normal;
                    r = 1;
                    g = 0;
                    b = 0;
                    bead = beadB.normal;


                }
                else if(abc ==asbcolor.red && collision.gameObject.CompareTag("Note_Blue") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.blue;
                    bead = beadB.blue;

                }
                else if(abc== asbcolor.red && collision.gameObject.CompareTag("Note_Green") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.green;
                    bead = beadB.green;
                }

            }
           else  if (abc == asbcolor.blue)
            {

                bead = beadB.blue;
                if (abc == asbcolor.blue && collision.gameObject.CompareTag("Note_Blue") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = true;
                    swordsound.Play();
                    Debug.Log("공격모드 활성화");
                    abc = asbcolor.normal;
                    r = 0;
                    b = 1;
                    g = 0;
                    bead = beadB.normal;

                }
                else if(abc == asbcolor.blue && collision.gameObject.CompareTag("Note_Red") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.red;
                    bead = beadB.red;

                }
                else if (abc == asbcolor.blue && collision.gameObject.CompareTag("Note_Green") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.green;
                    bead = beadB.green;
                }
            }

           else  if (abc == asbcolor.green)
            {
                bead = beadB.green;
                if (abc == asbcolor.green && collision.gameObject.CompareTag("Note_Green") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = true;
                    swordsound.Play();
                    Debug.Log("공격모드 활성화");
                    abc = asbcolor.normal;
                    r = 0;
                    b = 0;
                    g = 1;
                    bead = beadB.normal;
                }
                else if (abc == asbcolor.green && collision.gameObject.CompareTag("Note_Blue") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.blue;
                    bead = beadB.blue;
                }
                else if (abc == asbcolor.green && collision.gameObject.CompareTag("Note_Red") && Absorbmode == true)
                {
                    Destroy(collision.gameObject);
                    Attackmode = false;
                    abc = asbcolor.red;
                    bead = beadB.red;
                }
            }
         
        }
    }

    public void AbsorbButtonDown()
    {
        countTime = 0;
        StartCoroutine("AttackCooldown");
        BarrierUnColorTransparency();
        playerControl.ganglimAtk.sprite = playerControl.Change_GanglimAtk;

        if(Attackmode == false) { 

        Absorbmode = true;
        }
       
        if (Attackmode == true)
        {
            
            Debug.Log("공격 발사됨");
            Attackmode = false;
            abc = asbcolor.normal;
            r = 0;
            g = 0;
            b = 0;
        }
    }
    public void BarrierColorTransparency() // 흡수 투명도 0
    {
        absorptionSprite.color = new Color(0, 100, 100, 0f);
        absorption.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void BarrierUnColorTransparency() //흡수 투명도 100
    {
        absorptionSprite.color = new Color(0, 0, 0, 1f);
        absorption.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator AttackCooldown()
    {
        absorbBtn.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        absorbBtn.SetActive(true);
    }

}






