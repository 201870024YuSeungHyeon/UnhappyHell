using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note5 : MonoBehaviour
{
    public float noteSpeed = 400;
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(11, -100, 0) * 3 * Time.deltaTime;
    }
}