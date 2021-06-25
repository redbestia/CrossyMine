using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaeraMovmentGame : MonoBehaviour
{
    public CameraMovmentStrategy STRATEGY;

    private void Update()
    {
        STRATEGY.MoveCamera();
    }

}
