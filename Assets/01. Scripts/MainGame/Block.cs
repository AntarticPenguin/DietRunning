using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 _velocity = Vector2.zero;

	void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
	}
	
	void Update ()
    {
        Vector2 playerVelocity = MainGameManager.Instance.GetPlayer().GetVelocity();
        if(playerVelocity != _velocity)
        {
            _velocity = -playerVelocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
        }

    }
}
