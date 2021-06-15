using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ESCPause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject.FindGameObjectWithTag(Constants.pauseMenuTag).GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
}
