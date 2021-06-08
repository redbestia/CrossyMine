using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Tooltip("EnemySpeed")]
    float _speed = 1f;
    [SerializeField, Tooltip("StartPoint")]
    float _backPoints;
    float _startPoint;
    Rigidbody _rigidbody;

    Transform _transform;
   
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

    }

    private void Start()
    {
        _startPoint = _transform.position.x;
        _rigidbody.AddForce(new Vector3(-1.0f*_speed,0,0));
    }

    private void Update()
    {
        if (_transform.position.x > _startPoint + _backPoints || _transform.position.x < _startPoint - _backPoints)
            BackToStart();
    }
    private void BackToStart()
    {
        if (_startPoint >= _transform.position.x)
            _transform.position = _transform.position + new Vector3(_backPoints, 0, 0);
        else
            _transform.position = _transform.position - new Vector3(_backPoints, 0, 0);
    }
}
