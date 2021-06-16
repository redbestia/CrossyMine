using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledSpowner : MonoBehaviour
{
    [SerializeField, Tooltip("Reference Camera")] private GameObject _camera;
    [SerializeField, Tooltip("Field Prefab")] private GameObject _field;
    [SerializeField, Tooltip("Distance between each field")] private float _fieldDistanceSpawn;
    public float _difBetwenSpawnerAndCamera;
    private void Update()
    {
        FallowCamera();
    }
    void FallowCamera()
    {
        if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
        {
            transform.position += new Vector3(0,0,_fieldDistanceSpawn);
            GameObject field = Instantiate(_field);
            field.transform.position = transform.position;
        }
    }
}
