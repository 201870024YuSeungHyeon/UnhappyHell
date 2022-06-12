using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Manager : MonoBehaviour
{
    public GameObject[] AttackPrefab;
    [SerializeField] Transform tfNoteAppear = null;
    AttackEvent attackEvent;
   
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        attackEvent = FindObjectOfType<AttackEvent>(); //PlayerControl참조하기
    }

    void Update()
    {      
        ShootAttack();       
    }

    public void ShootAttack()
    {
        if (attackEvent.Attackmode == true && attackEvent.r == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[0], tfNoteAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;

        }
        if (attackEvent.Attackmode == true && attackEvent.b == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[1], tfNoteAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;
        }
        if (attackEvent.Attackmode == true && attackEvent.g == 1)
        {
            GameObject t_attack = Instantiate(AttackPrefab[2], tfNoteAppear.position, Quaternion.identity);
            t_attack.transform.SetParent(this.transform);
            attackEvent.Attackmode = false;
        }
    }

    
}
