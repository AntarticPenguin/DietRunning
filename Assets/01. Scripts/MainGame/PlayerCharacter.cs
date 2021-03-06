﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //Unity Functions

	void Start ()
    {
        
	}
	
	void Update ()
    {
        //Check on Ground
        LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hitFromGround = Physics2D.Raycast(transform.position, Vector3.down, 2.0f, groundMask);
        if(null != hitFromGround.transform)
        {
            if(false == _isGround)
            {
                _isGround = true;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
        else
        {
            if(true == _isGround)
            {
                _isGround = false;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if("Block" == collision.tag)
        {
            _player.ResetSpeed();
        }
    }


    //Init

    Player _player;

    public void Init(Player player)
    {
        _player = player;
    }


    //Character's State

    public void IdleState()
    {
        GetAnimator().SetFloat("Horizontal", 0.0f);
    }

    public void RunState()
    {
        GetAnimator().SetFloat("Horizontal", 1.0f);
    }


    //Move

    bool _isGround = false;
    bool _canDoubleJump = false;

    public void Jump(float jumpSpeed)
    {
        if(true == _isGround)
        {
            JumpAction(jumpSpeed);

            if(MainGameManager.Instance.GetPlayer().GetCurrentWeight() < 80.0f)
                _canDoubleJump = true;
            else
                _canDoubleJump = false;
        }
        else if(true == _canDoubleJump)
        {
            JumpAction(jumpSpeed);
            _canDoubleJump = false;
        }
    }

    void JumpAction(float jumpSpeed)
    {
        GetAnimator().SetTrigger("Jump");

        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.y = jumpSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }


    //Animator

    Animator GetAnimator()
    {
        return gameObject.GetComponent<Animator>();
    }
}
