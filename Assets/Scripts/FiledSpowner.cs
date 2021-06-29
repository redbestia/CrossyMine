using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledSpowner : MonoBehaviour
{
    public float _difBetwenSpawnerAndCamera;

    [SerializeField, Tooltip("Reference Camera")] 
    private GameObject _camera;
    [SerializeField, Tooltip("Field Prefab")]
    private GameObject _field;
    [SerializeField, Tooltip("Distance between each field")]
    private float _fieldDistanceSpawn;

    private void Update()
    {
        FallowCamera();
    }

    void FallowCamera()
    {
        if (CameraShouldFollowConstantOffsetFromPlayerToCamera())
        {
            transform.position += new Vector3(0, 0, _fieldDistanceSpawn);
            GameObject field = Instantiate(_field);
            field.transform.position = transform.position;
        }
    }

    private bool CameraShouldFollowConstantOffsetFromPlayerToCamera()
    {
        return transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera;
    }
}
