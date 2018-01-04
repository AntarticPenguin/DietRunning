using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text GameOverText;

    //Unity Functions

	void Start ()
    {
        GameOverText.gameObject.SetActive(false);
	}
	
	void Update ()
    {
        if(MainGameManager.Instance.GetPlayer().IsDead())
        {
            GameOverText.gameObject.SetActive(true);
        }
	}
}
