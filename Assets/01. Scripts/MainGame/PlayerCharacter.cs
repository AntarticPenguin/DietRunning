using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //Unity Functions

	void Start ()
    {
        ChangeState(eState.RUN);    
	}
	
	void Update ()
    {
		
	}

    //Character's State

    public enum eState
    {
        IDLE,
        RUN,
    };

    void ChangeState(eState state)
    {
        switch(state)
        {
            case eState.IDLE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                GetAnimator().SetBool("isGround", true);
                break;
            case eState.RUN:
                _velocity.x = 10.0f;
                _velocity.y = 0.0f;
                GetAnimator().SetBool("isGround", true);
                GetAnimator().SetFloat("Horizontal", _velocity.x);
                break;
        }
    }

    //Move

    Vector2 _velocity = Vector2.zero;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    //Animator
    
    Animator GetAnimator()
    {
        return gameObject.GetComponent<Animator>();
    }
}
