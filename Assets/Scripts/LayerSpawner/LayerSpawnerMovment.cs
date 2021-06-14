using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{
    public class LayerSpawnerMovment : MonoBehaviour
    {
        public int rockSpawnChance;
        public int enemySpawnChance;
        public int noRockSpawnChance;
        int _allChance;
        [SerializeField, Tooltip("Reference Camera")] private GameObject _camera;
        Vector3 _moveVector = new Vector3(0.0f, 0.0f, 2.0f);
        public float _difBetwenSpawnerAndCamera;
        SideRocksCreator _sideRockCreator;
        InsideRocksCreator _insideRocksCreator;
        EnemySpawner _enemySpawner;
        SpecialInsideRocksCreator _specialInsideRocksCreator;
        int _layerCounter = 1;
        int _switchCase;
        int _switchCaseOneBack;

        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
            _enemySpawner = GetComponent<EnemySpawner>();
            _specialInsideRocksCreator = GetComponent<SpecialInsideRocksCreator>();
        }
        private void Update()
        {
            SpawnMoveSpawner();
        }

        void SpawnMoveSpawner()
        {
            if (transform.position.z < _camera.transform.position.z + _difBetwenSpawnerAndCamera)
            {
                _allChance = rockSpawnChance + noRockSpawnChance + enemySpawnChance;
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
                
                if (_switchCase == 0 | _switchCase == 3)
                {
                    _switchCaseOneBack = _switchCase;
                    _switchCase = Random.Range(1, 3);
                }
                else if (_switchCase == 1 & _switchCaseOneBack == 0)
                {
                    _switchCaseOneBack = _switchCase;
                    _switchCase = Random.Range(1, 4);
                }
                else
                {
                    _switchCaseOneBack = _switchCase;
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
                case 3:
                    _specialInsideRocksCreator.CreateSpecialInsideRocks();
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