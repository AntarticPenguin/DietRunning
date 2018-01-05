using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    public Text GameCompleteText;
    
    //Unity Functions

	void Start ()
    {
        GameCompleteText.gameObject.SetActive(false);	
	}
	
	void Update ()
    {
	    if(MainGameManager.Instance.GetPlayer().IsComplete())
        {
            if(MainGameManager.Instance.GetPlayer().IsSuccess())
            {
                GameCompleteText.text = "SUCCESS";
            }
            else
            {
                GameCompleteText.text = "FAIL";
            }
            GameCompleteText.gameObject.SetActive(true);
        }
	}
}
