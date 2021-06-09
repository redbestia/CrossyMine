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
        EnemySpawner _enemySpawner;
        int _layerCounter = 1;

        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
            _enemySpawner = GetComponent<EnemySpawner>();
        }
        private void Update()
        {
            SpawnMoveSpawner();        }

        void SpawnMoveSpawner()
        {
            if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            {

                if (_layerCounter % 3 == 0)
                {
                    _insideRocksCreator.CreateInsideRocks();
                    _sideRockCreator.CreateSideRocks();
                }
                if (_layerCounter % 3 == 1) _enemySpawner.SpawnEnemy();
                if (_layerCounter % 3 == 2) _sideRockCreator.CreateSideRocks();
                
                _layerCounter++;
                transform.position += _moveVector;

            }
        }

    }
}