using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

    int _score = 0;
    bool _dietResult = false;
    public Text _scoreText;
    public Text _successText;
    public Text _failText;

    //Unity Functions

    void Start ()
    {
        _successText.gameObject.SetActive(false);
        _failText.gameObject.SetActive(false);

        _score = ScoreManager.Instance.GetScore();
        _dietResult = ScoreManager.Instance.GetDietResult();

        _scoreText.text = "SCORE: " + _score.ToString("D6");
	}

    void Update()
    {
        if (true == _dietResult)
        {
            _successText.gameObject.SetActive(true);
        }
        else
        {
            _failText.gameObject.SetActive(true);
        }
    }
}
