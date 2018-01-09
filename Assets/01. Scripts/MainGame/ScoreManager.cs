using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Singleton

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
    }


    //Unity Functions

    void Start ()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	void Update ()
    {
        if(null != MainGameManager.Instance)
            _score = (int)(MainGameManager.Instance.GetPlayer().GetDistance() * 100);
	}


    //Score

    int _score = 0;
    bool _dietResult = false;

    public int GetScore()
    {
        return _score;
    }

    public bool GetDietResult()
    {
        return _dietResult;
    }

    public void SetDietResult(bool result)
    {
        _dietResult = result;
    }
}
