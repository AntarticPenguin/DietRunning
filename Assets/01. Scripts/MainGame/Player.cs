using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;


    //Unity Functions
    
	void Start ()
    {
        PlayerView.Init(this);
        ChangeState(eState.RUN);
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        //Acceleration
        if(eState.RUN == _state)
        {
            if(_velocity.x < _maxSpeed)
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }
        }
    }


    //Character's State

    public enum eState
    {
        IDLE,
        RUN,
    };

    eState _state = eState.IDLE;

    public void ChangeState(eState state)
    {
        _state = state;

        switch (state)
        {
            case eState.IDLE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.RUN:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.RunState();
                break;
        }
    }


    //Move

    Vector2 _velocity = Vector2.zero;

    //for test
    public float _maxSpeed = 15.0f;
    public float _addSpeed = 0.05f;
    public float _jumpSpeed = 10.0f;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    public void ResetSpeed()
    {
        _velocity.x = 0.0f;
    }
}
