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
        StartGame();
	}
	
	void Update ()
    {
		
	}


    // GameState
    
    void StartGame()
    {
        PlayerCharacterScript.ChangeState(Player.eState.RUN);
        BlockCreatorScript.StartCreate();
    }


    //GameObjects

    public Player PlayerCharacterScript;
    public BlockCreator BlockCreatorScript;

    public Player GetPlayer()
    {
        return PlayerCharacterScript;
    }
}
