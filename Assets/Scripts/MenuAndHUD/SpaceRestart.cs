using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CrossyMine;

public class SpaceRestart : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space ))
        {
            RestartGame.RestartStatic();
        }
    }
}
