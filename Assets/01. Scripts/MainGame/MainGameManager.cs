using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    //Singleton
    private static MainGameManager _instance;
    public static MainGameManager Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = FindObjectOfType<MainGameManager>();
            }
            return _instance;
        }
    }

    //Unity Functions
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    //GameObjects

    public PlayerCharacter PlayerCharacterScript;

    public PlayerCharacter GetPlayer()
    {
        return PlayerCharacterScript;
    }
}
