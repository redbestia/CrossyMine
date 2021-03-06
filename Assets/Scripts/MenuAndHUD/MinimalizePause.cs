using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class MinimalizePause : MonoBehaviour
{
    bool _ifChecker = false; //Dont want pasue at the start of the game
    private void OnApplicationFocus(bool focus)
    {
        if (_ifChecker == true && focus == false)
        {
            GameObject.FindGameObjectWithTag(Constants.PauseMenuTag).
                GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag(Constants.AudioHolder).
                GetComponent<AudioSource>().mute = true;
        }
        else GameObject.FindGameObjectWithTag(Constants.AudioHolder).
                GetComponent<AudioSource>().mute = false;
        _ifChecker = true;
        
    }
}
