using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class DieFromTooSlow : Die
{
    GameObject _camera;

    [SerializeField, Tooltip("Differnce in z position between player and camaera to kill player")] float _DistanceBetweenCameraAndPlayer; 
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag(Constants.mainCameraTag);
    }
    private void Update()
    {
        if (_camera.transform.position.z > transform.position.z + _DistanceBetweenCameraAndPlayer)
        {
            PlayerDied();
        }
    }
}

