using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Tooltip("EnemySpeed")] float _speed = 1f;
    [SerializeField, Tooltip("Max Point Top")] float _maxTop;
    [SerializeField, Tooltip("Max Point Down")] float _maxDown;
    [SerializeField, Tooltip("Yes =going top No= going down")] bool _topOrDown;
    Rigidbody _rigidbody;

    Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

    }

    private void Start()
    {
        if(_topOrDown) _rigidbody.AddForce(new Vector3(-1.0f * _speed, 0, 0));
        else _rigidbody.AddForce(new Vector3(1.0f * _speed, 0, 0));
    }

    private void Update()
    {
        if(_topOrDown) BackToStartTop();
            
        else BackToStartDown();
            
    }
    private void BackToStartTop()
    {
        if (_maxTop >= _transform.position.x)
            _transform.position = new Vector3(_maxDown, _transform.position.y, _transform.position.z);
     
    }
    private void BackToStartDown()
    {
        if (_maxDown <= _transform.position.x)
            _transform.position = new Vector3(_maxTop, _transform.position.y, _transform.position.z);
    }
}
