using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ESCPause : MonoBehaviour
{
    private void Update()// Pause if press ESC
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject.FindGameObjectWithTag(Constants.PauseMenuTag).GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
}
