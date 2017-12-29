using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    //Unity Functions
    
	void Start ()
    {
        
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump();
        }
    }

    //Character's State

    public enum eState
    {
        IDLE,
        RUN,
    };

    public void ChangeState(eState state)
    {
        switch (state)
        {
            case eState.IDLE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.RUN:
                _velocity.x = 10.0f;
                _velocity.y = 0.0f;
                PlayerView.RunState();
                break;
        }
    }

    //Move

    Vector2 _velocity = Vector2.zero;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }
}
