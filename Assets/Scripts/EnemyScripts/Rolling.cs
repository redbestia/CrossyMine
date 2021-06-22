using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    EnemyMovement _enemyMovment;

    private void Awake()
    {
        _enemyMovment = GetComponent<EnemyMovement>();
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotationSpeed * _enemyMovment.speed);
    }

}
