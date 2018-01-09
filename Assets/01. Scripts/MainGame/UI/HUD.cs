using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text WeightText;
    public Text JumpInfoText;
    public Text RemainDistanceText;
    public Text currentSpeedText;
    public Text ScoreText;


    //Unity Functions

    void Start ()
    {
	    	
	}
	
	void Update ()
    {
        WeightText.text = "체중: " + MainGameManager.Instance.GetPlayer().GetCurrentWeight().ToString("N2")
                            + " / " + MainGameManager.Instance.GetPlayer().GetGoalWeight();

        if (MainGameManager.Instance.GetPlayer().CanDoubleJump())
        {
            JumpInfoText.text = "DOUBLE JUMP";
        }
        else
        {
            JumpInfoText.text = "SINGLE JUMP";
        }

        float maxDistance = MainGameManager.Instance.GetPlayer().GetMaxDistance();
        float distance = MainGameManager.Instance.GetPlayer().GetDistance();
        int remainDistance = (int)(maxDistance - distance);

        RemainDistanceText.text = "남은거리: " + remainDistance;
        currentSpeedText.text = "현재속도: " + MainGameManager.Instance.GetPlayer().GetCurrentSpeed().ToString("N2");
        ScoreText.text = ScoreManager.Instance.GetScore().ToString("D8");
    }
}
