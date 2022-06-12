using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 position;
    public float attackSpeed = 1500;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        position.y += attackSpeed * Time.deltaTime;
        transform.position = position;
    }
}