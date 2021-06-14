using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField, Tooltip("CameraSpeed")]
    public float speed = 1f;
    Rigidbody _rigidbody;
    Transform _playerTransform;
    Vector3 _moveVector;
    Vector3 _positionVector;
    [SerializeField, Tooltip("Camera position in relation to player")] float _cameraPositionToPlayer;
    public float slowJumpCamera;
    public float slowCamera;
    public float endOfSpeedingCamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = GameObject.FindGameObjectWithTag(Constants.playerTag).transform;
        _moveVector = new Vector3(0, 0, speed);

        _positionVector = transform.position;

        transform.position = _positionVector + new Vector3(0, 0, (_playerTransform.position.z - _positionVector.z) / slowJumpCamera);

        _positionVector += new Vector3(0, 0, (speed / 100) * (_playerTransform.position.z - _positionVector.z + endOfSpeedingCamera) / slowCamera);
    }
    private void FixedUpdate()
    {
        transform.position = _positionVector + new Vector3(0, 0, (_playerTransform.position.z - _positionVector.z) / slowJumpCamera);

        _positionVector += new Vector3(0, 0, (speed / 100) * (_playerTransform.position.z - _positionVector.z + endOfSpeedingCamera)/slowCamera);
    }
}