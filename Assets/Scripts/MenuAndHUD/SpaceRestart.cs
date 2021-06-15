using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceRestart : MonoBehaviour
{
    int _ifChecker = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) & _ifChecker == 0)
        {
            Time.timeScale = 1;
            _ifChecker = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
