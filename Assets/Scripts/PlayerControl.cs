using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    double x;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LButtonDown()
    {
        transform.Translate(-1, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(1, 0, 0);
    }
}
