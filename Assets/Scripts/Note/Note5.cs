using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note5 : MonoBehaviour
{
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(11, -100, 0) * 7 * Time.deltaTime;
    }
}