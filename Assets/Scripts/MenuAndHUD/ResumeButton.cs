﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        GameObject.FindGameObjectWithTag(Constants.PauseMenuTag).GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
}
