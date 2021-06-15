﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class PauseButton : MonoBehaviour
{
    public void ShowPauseMenu()
    {
        GameObject.FindGameObjectWithTag(Constants.pauseMenuTag).GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
    }
}
