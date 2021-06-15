using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class GameStarter : MonoBehaviour
{
    int _ifChecker = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow) & _ifChecker == 0)
        {
            StartGame();
            _ifChecker = 1;
        }
    }
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag(Constants.playerTag).GetComponent<PlayerController>().enabled = true;
        GameObject.FindGameObjectWithTag(Constants.mainCameraTag).GetComponent<CameraMovment>().enabled = true;
        GameObject.FindGameObjectWithTag(Constants.startMenuTag).GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag(Constants.pauseMenuTag).GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
}
