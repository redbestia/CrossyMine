using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class ObjectDestroyerMovement : MonoBehaviour
{
    
   // Rigidbody _rigidbody;
    GameObject _camera;
    //  CameraMovment _cameraMovment;
    public int distanceBetweenCamera;
    private void Awake()
    {
   //     _rigidbody = GetComponent<Rigidbody>();
        _camera = GameObject.FindWithTag(Constants.mainCameraTag);
   //     _cameraMovment = _camera.GetComponent<CameraMovment>();
    }
    private void Update()
    {
        //    _rigidbody.AddForce(new Vector3(0, 0, _cameraMovment.speed));
        transform.position = _camera.transform.position - new Vector3(0, 0, distanceBetweenCamera);
    }
}
