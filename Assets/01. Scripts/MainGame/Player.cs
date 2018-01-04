using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;


    //Unity Functions
    
	void Start ()
    {
        _currentWeight = _startWeight;
        _currentHP = _maxHP;

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

        UpdateWeight();
        UpdateHP();
    }


    //Character's State

    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
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
            case eState.DEATH:
                _velocity.x = 0;
                _velocity.y = 0;
                PlayerView.IdleState();
                break;
        }
    }

    public bool IsDead()
    {
        if(eState.DEATH == _state)
            return true;
        return false;
    }


    //Character's Info

    float _maxHP = 100.0f;
    float _decreaseHP = 0.1f;
    float _currentHP = 0.0f;

    float _maxWeight = 120.0f;
    float _minWeight = 40.0f;
    float _startWeight = 100.0f;
    float _decreaseWeight = 0.05f;
    float _currentWeight = 0.0f;

    void UpdateWeight()
    {
        _currentWeight -= _decreaseWeight;
        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;

        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
    }

    void UpdateHP()
    {
        _currentHP -= _decreaseHP;
        if (_currentHP < 0)
        {
            _currentHP = 0;

            ChangeState(eState.DEATH);
        }
    }

    public float GetMaxHP()
    {
        return _maxHP;
    }

    public float GetCurrentHP()
    {
        return _currentHP;
    }

    public void IncreaseHP(float addHP)
    {
        _currentHP += addHP;
        if (_maxHP < _currentHP)
            _currentHP = _maxHP;
    }

    public float GetMaxWeight()
    {
        return _maxWeight;
    }

    public float GetMinWeight()
    {
        return _minWeight;
    }

    public float GetCurrentWeight()
    {
        return _currentWeight;
    }

    public void AddWeight(float addWeight)
    {
        _currentWeight += addWeight;
        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;
        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
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
