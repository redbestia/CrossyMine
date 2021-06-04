using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledSpowner : MonoBehaviour
{
    [SerializeField, Tooltip("Reference Camera")] private GameObject _camera;
    Vector3 _moveVector = new Vector3(0.0f,0.0f,20.0f);
    float _difBetwenSpawnerAndCamera = 10;
    private void Update()
    {
        FallowCamera();
    }
    void FallowCamera()
    {
        if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            transform.position += _moveVector;
    }
}
