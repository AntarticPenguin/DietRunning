using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text WeightText;
    public Text MaxSpeedText;
    public Text CurrentSpeedText;
    public Text JumpInfoText;
    public Text RemainDistanceText;


    //Unity Functions

    void Start ()
    {
	    	
	}
	
	void Update ()
    {
        WeightText.text = "체중: " + MainGameManager.Instance.GetPlayer().GetCurrentWeight().ToString("N2")
                            + " / " + MainGameManager.Instance.GetPlayer().GetGoalWeight();
        MaxSpeedText.text = "최대속도: " + MainGameManager.Instance.GetPlayer().GetMaxSpeed();
        CurrentSpeedText.text = "속도: " + MainGameManager.Instance.GetPlayer().GetSpeed();


        if (MainGameManager.Instance.GetPlayer().CanDoubleJump())
        {
            JumpInfoText.text = "더블점프: 가능";
        }
        else
        {
            JumpInfoText.text = "더블점프: 불가";
        }

        float maxDistance = MainGameManager.Instance.GetPlayer().GetMaxDistance();
        float distance = MainGameManager.Instance.GetPlayer().GetDistance();
        int remainDistance = (int)(maxDistance - distance);

        RemainDistanceText.text = "남은거리: " + remainDistance;
    }
}
