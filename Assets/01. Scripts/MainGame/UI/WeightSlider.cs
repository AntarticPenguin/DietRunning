using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightSlider : MonoBehaviour
{

    //Unity Functions
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        float maxWeight = MainGameManager.Instance.GetPlayer().GetMaxWeight();
        float minWeight = MainGameManager.Instance.GetPlayer().GetMinWeight();
        float currentWeight = MainGameManager.Instance.GetPlayer().GetCurrentWeight();

        //float maxLength = maxWeight - minWeight;
        //float currentLength = currentWeight - minWeight;
        //float rate = currentLength / maxLength;
        float rate = currentWeight / maxWeight;

        gameObject.GetComponent<Slider>().value = rate;
	}
}
