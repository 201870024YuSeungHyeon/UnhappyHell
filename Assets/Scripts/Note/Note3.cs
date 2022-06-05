using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note3 : MonoBehaviour
{
    public float noteSpeed = 400;
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(0, -100, 0) * 5 * Time.deltaTime;
    }
}