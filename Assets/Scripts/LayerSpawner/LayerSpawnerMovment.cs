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
        SideRocksCreator _sideRockCreator;
        InsideRocksCreator _insideRocksCreator;
        int _layerCounter = 1;

        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
        }
        private void Update()
        {
            SpawnMoveSpawner();        }

        void SpawnMoveSpawner()
        {
            if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            {
                _sideRockCreator.CreateSideRocks();
                if(_layerCounter % 2 == 0) _insideRocksCreator.CreateInsideRocks();
                _layerCounter++;
                transform.position += _moveVector;

            }
        }

    }
}