using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ObjectDestroyerMovement : MonoBehaviour
{
    GameObject _camera;
    public int distanceBetweenCamera;

    private void Awake()
    {
        _camera = GameObject.FindWithTag(Constants.MainCameraTag);
    }

    private void Update()
    {
        transform.position = _camera.transform.position - new Vector3(0, 0, distanceBetweenCamera);
    }
}
