using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    GameStart gameStart;
    void Start()
    {
        gameStart = GameObject.Find("GameStart").GetComponent<GameStart>();
        
    }
    public void Touch()
    {
        
    }

    void Update()
    {
        
    }
}
