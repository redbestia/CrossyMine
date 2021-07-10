using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class GameStarter : MonoBehaviour
{
    int _ifChecker = 0; 
    private void Update()
    {
        if (IsInput())
        {
            StartGame();
            _ifChecker = 1;
        }
    }

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<PlayerController>().enabled = true;
        GameObject.FindGameObjectWithTag(Constants.MainCameraTag).GetComponent<CameraMovment>().enabled = true;
        GameObject.FindGameObjectWithTag(Constants.StartMenuTag).GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag(Constants.PauseMenuTag).GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    private bool IsInput()
    {
        return Input.GetKey(KeyCode.UpArrow)
            | Input.GetKey(KeyCode.DownArrow)
            | Input.GetKey(KeyCode.RightArrow)
            | Input.GetKey(KeyCode.LeftArrow)
            & _ifChecker == 0;
    }
}
