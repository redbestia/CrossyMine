using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{
    public class LayerSpawnerMovment : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference Camera")] private GameObject _camera;
        Vector3 _moveVector = new Vector3(0.0f, 0.0f, 2.0f);
        public float _difBetwenSpawnerAndCamera;
        private RocksCreator _rockCreator;

        private void Awake()
        {
            _rockCreator = GetComponent<RocksCreator>();
        }
        private void Update()
        {
            MoveSpawner();
        }

        void MoveSpawner()
        {
            if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            {
                _rockCreator.CreateSideRocks();
                transform.position += _moveVector;
            }
        }

    }
}