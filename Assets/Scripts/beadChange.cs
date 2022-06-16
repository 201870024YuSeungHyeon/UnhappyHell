using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beadChange : MonoBehaviour
{
    AttackEvent attackEvent;
    public Sprite bead_Red, bead_blue, bead_Green, bead_Normal;
    SpriteRenderer thisImg;
    // Start is called before the first frame update
    void Start()
    {
        attackEvent = FindObjectOfType<AttackEvent>();
        thisImg = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackEvent.bead == AttackEvent.beadB.normal)
        {
            thisImg.sprite = bead_Normal;
        }
        if (attackEvent.bead == AttackEvent.beadB.red)
        {
            thisImg.sprite = bead_Red;
        }
        if (attackEvent.bead == AttackEvent.beadB.blue)
        {
            thisImg.sprite = bead_blue;
        }
        if (attackEvent.bead == AttackEvent.beadB.green)
        {
            thisImg.sprite = bead_Green;
        }
    }
}
