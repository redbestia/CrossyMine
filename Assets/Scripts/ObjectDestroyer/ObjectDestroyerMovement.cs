using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ObjectDestroyerMovement : MonoBehaviour
{
    
    Rigidbody _rigidbody;
    GameObject _camera;
    CameraMovment _cameraMovment;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GameObject.FindWithTag(Constants.mainCameraTag);
        _cameraMovment = _camera.GetComponent<CameraMovment>();
    }
    private void Start()
    {
        _rigidbody.AddForce(new Vector3(0, 0, _cameraMovment.speed));
    }
}
