using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField, Tooltip("CameraSpeed")]
    float _speed = 1f;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        _rigidbody.AddForce(new Vector3(0, 0, 1.0f * _speed));
    }
}
