﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{



    //Unity Functions

    void Start()
    {
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if("Player" == collision.tag)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
