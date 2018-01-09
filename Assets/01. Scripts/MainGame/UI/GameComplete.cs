using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public Text GameCompleteText;
    float _sceneChangeInterval = 2.0f;
    float _deltaScene = 0.0f;
    
    //Unity Functions

	void Start ()
    {
        GameCompleteText.gameObject.SetActive(false);	
	}
	
	void Update ()
    {
        if (MainGameManager.Instance.GetPlayer().IsComplete())
        {
            if (MainGameManager.Instance.GetPlayer().IsSuccess())
            {
                GameCompleteText.text = "SUCCESS";
                ScoreManager.Instance.SetDietResult(true);
            }
            else
            {
                GameCompleteText.text = "FAIL";
                ScoreManager.Instance.SetDietResult(false);
            }
            GameCompleteText.gameObject.SetActive(true);

            _deltaScene += Time.deltaTime;
            if (_sceneChangeInterval <= _deltaScene)
                SceneManager.LoadScene("ResultScene");
        }
	}
}
