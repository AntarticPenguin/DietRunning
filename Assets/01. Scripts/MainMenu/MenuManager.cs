﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //Unity Functions

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
            SceneManager.LoadScene("MainGame");
    }
}
