﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    Vector2 _velocity = Vector2.zero;


    //Unity Functions

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    void Update()
    {
        Vector2 playerVelocity = MainGameManager.Instance.GetPlayer().GetVelocity();
        if (playerVelocity != _velocity)
        {
            _velocity = -playerVelocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
        }

        if (transform.position.x < -15)
        {
            GameObject.Destroy(gameObject, 2.0f);
        }
    }
}
