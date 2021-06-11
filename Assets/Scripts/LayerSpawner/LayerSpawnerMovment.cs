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
        int _switchCase;

        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
            _enemySpawner = GetComponent<EnemySpawner>();
        }
        private void Update()
        {
            SpawnMoveSpawner();
        }

        void SpawnMoveSpawner()
        {
            if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            {
                SafeStartOrNoramlSpawn();
                SwitchWhatLayerSpawn();
                AddToLayerCounter();
                MoveSpawnerForward();

            }
        }
        void SafeStartOrNoramlSpawn()
        {
            if (_layerCounter <= 5)
            {
                _switchCase = 2;
            }
            else
            {
                if (_switchCase == 0)
                {
                    _switchCase = Random.Range(1, 3);
                }
                else
                {
                    _switchCase = Random.Range(0, 3);
                }
            }
        }
        void SwitchWhatLayerSpawn()
        {
            switch (_switchCase)
            {
                case 0:
                    _insideRocksCreator.CreateInsideRocks();
                    _sideRockCreator.CreateSideRocks();
                    break;
                case 1:
                    _enemySpawner.SpawnEnemy();
                    break;
                case 2:
                    _sideRockCreator.CreateSideRocks();
                    break;
            }
        }
        void AddToLayerCounter()
        {

            _layerCounter++;
        }
        void MoveSpawnerForward()
        {

            transform.position += _moveVector;
        }
    }
}