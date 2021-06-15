using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class MinimalizePause : MonoBehaviour
{
    bool _ifChecker = false;
    private void OnApplicationFocus(bool focus)
    {
        if(_ifChecker == true)
        {
            GameObject.FindGameObjectWithTag(Constants.pauseMenuTag).GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        _ifChecker = true;
    }
}
