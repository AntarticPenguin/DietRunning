using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    public Text DescriptionText;
    bool turnOn = true;
    float _turnInterval = 0.5f;
    float _deltaTurn = 0.0f;


    void Start ()
    {
		
	}
	
	void Update ()
    {
        _deltaTurn += Time.deltaTime;
        if (_turnInterval <= _deltaTurn)
        {
            _deltaTurn = 0;
            turnOn = !turnOn;
            DescriptionText.gameObject.SetActive(turnOn);
        }
	}
}
