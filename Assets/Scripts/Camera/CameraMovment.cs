using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField, Tooltip("CameraSpeed")]
    Rigidbody _rigidbody;
    [SerializeField, Tooltip("Camera position in relation to player")] 
    public float speed = 1f;

    public float slowJumpCamera;
    public float slowCamera;
    public float endOfSpeedingCamera;

    Transform _playerTransform;
    Vector3 _positionVector;

    float diffBetweenPlayerAndPositionVector;

    #region MonoBehaviour

    private void Awake()
    {
        GetRigidbodyAndPlayerTransform();
        PrepearPositionVector();
        MoveCamera();
    }
    private void FixedUpdate()
    {
        MoveCamera();
    }
    #endregion
    void GetRigidbodyAndPlayerTransform()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = GameObject.FindGameObjectWithTag(Constants.PlayerTag).transform;
    }
    void PrepearPositionVector()
    {
        _positionVector = transform.position;
    }
    void MoveCamera()
    {
        diffBetweenPlayerAndPositionVector = _playerTransform.position.z - _positionVector.z;

        transform.position = _positionVector + new Vector3(0, 0, 
            (diffBetweenPlayerAndPositionVector) / slowJumpCamera);

        _positionVector += new Vector3(0, 0, (speed / 100) * 
            (diffBetweenPlayerAndPositionVector + endOfSpeedingCamera) / slowCamera);
    }

}