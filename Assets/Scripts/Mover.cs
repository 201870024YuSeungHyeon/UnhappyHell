using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject[] playerHp;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1.7f;

    void Start()
    {
//        hpBar = Instantiate(hpImage, canvas.transform).GetComponent<RectTransform>();
    }


    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
    }
}
