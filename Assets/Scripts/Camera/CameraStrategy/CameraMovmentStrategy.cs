using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public abstract class CameraMovmentStrategy : ScriptableObject
{
    public GameObject camera;
    public GameObject player;
    public abstract void MoveCamera();
    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag(Constants.mainCameraTag);
        player = GameObject.FindGameObjectWithTag(Constants.playerTag);
    }
}
