﻿using System.Collections;
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

        _distance = 0.0f;

        PlayerView.Init(this);
        ChangeState(eState.RUN);
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        UpdateDistance();

        //Acceleration
        if (eState.RUN == _state)
        {
            //UpdateDistance();

            if(_velocity.x < _maxSpeed)
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }

            UpdateWeight();
            UpdateHP();

            UpdateSpeedByWeight();
        }
    }

    void UpdateWeight()
    {
        float decreaseWeight = _coefficientWeight * Mathf.Log10(_velocity.x);
        _currentWeight -= decreaseWeight;
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

    void UpdateSpeedByWeight()
    {
        if(100.0f < _currentWeight)
        {
            _maxSpeed = 8.0f;
        }
        else if (80.0f < _currentWeight)
        {
            _maxSpeed = 13.0f;
        }
        else if (60.0f < _currentWeight)
        {
            _maxSpeed = 15.0f;
        }
        else if (40.0f < _currentWeight)
        {
            _maxSpeed = 12.0f;
        }  
    }

    void UpdateDistance()
    {
        float deltaDistance = _velocity.x * Time.deltaTime;
        _distance += deltaDistance;
        if( _maxDistance <= _distance)
        {
            ChangeState(eState.COMPLETE);
        }
    }


    //Character's State

    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
        COMPLETE,
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
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.COMPLETE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
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

    public bool IsComplete()
    {
        if (eState.COMPLETE == _state)
            return true;
        return false;
    }

    public bool IsSuccess()
    {
        float weightPercent = (_currentWeight / _goalWeight) * 100;
        if (90.0f < weightPercent)
            return true;
        return false;
    }


    //Hp

    float _maxHP = 100.0f;
    float _currentHP = 0.0f;

    //for test
    public float _decreaseHP = 0.1f;

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


    //Weight

    float _maxWeight = 120.0f;
    float _minWeight = 40.0f;
    float _startWeight = 100.0f;
    float _currentWeight = 0.0f;
    float _goalWeight = 70.0f;

    //for test
    public float _coefficientWeight = 0.05f;

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

    public float GetGoalWeight()
    {
        return _goalWeight;
    }

    public void AddWeight(float addWeight)
    {
        _currentWeight += addWeight;
        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;
        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
    }


    //Move & Speed

    Vector2 _velocity = Vector2.zero;

    float _maxSpeed = 12.0f;
    float _addSpeed = 0.05f;

    float _maxDistance = 200.0f;
    float _distance = 0.0f;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    public void ResetSpeed()
    {
        _velocity.x = 0.0f;
    }

    public float GetMaxDistance()
    {
        return _maxDistance;
    }

    public float GetDistance()
    {
        return _distance;
    }

    public float GetCurrentSpeed()
    {
        return _velocity.x;
    }


    //Jump

    float _jumpSpeed = 19.0f;

    public bool CanDoubleJump()
    {
        if (MainGameManager.Instance.GetPlayer().GetCurrentWeight() < 80.0f)
            return true;
        else
            return false;
    }
}
