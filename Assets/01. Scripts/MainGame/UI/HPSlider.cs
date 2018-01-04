using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    //Unity Functions

	void Start ()
    {
		
	}
	
	void Update ()
    {
        float maxHP = MainGameManager.Instance.GetPlayer().GetMaxHP();
        float currentHP = MainGameManager.Instance.GetPlayer().GetCurrentHP();
        float rate = currentHP / maxHP;

        gameObject.GetComponent<Slider>().value = rate;
	}
}
