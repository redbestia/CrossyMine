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
        OutsideRockCreator _outsideRockCreator;
        EnemySpawner _enemySpawner;
        SpecialInsideRocksCreator _specialInsideRocksCreator;
        CreatorEnemySpawner _creatorEnemySpawner;
        int _layerCounter = 1;
        int _switchCase;
        int _switchCaseOneBack;

        #region MonoBehaviour
        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
            _enemySpawner = GetComponent<EnemySpawner>();
            _specialInsideRocksCreator = GetComponent<SpecialInsideRocksCreator>();
            _outsideRockCreator = GetComponent<OutsideRockCreator>();
            _creatorEnemySpawner = GetComponent<CreatorEnemySpawner>();
        }
        private void Update()
        {
            SpawnMoveSpawner();
        }
        #endregion
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
                    _switchCase = RandomNumberToSwitchNumberWithoutInsideRocks();
                }
                else if (_switchCase == 1 & _switchCaseOneBack == 0 || _switchCase == 1 & _switchCaseOneBack == 3)
                {
                    _switchCaseOneBack = _switchCase;
                    _switchCase = RandomNumberToSwitchNumberWithSpecialRocks();
                }
                else
                {
                    _switchCaseOneBack = _switchCase;
                    _switchCase = RandomNumberToSwitchNumberNormal();
                }
            }
        }
        int RandomNumberToSwitchNumberWithoutInsideRocks()
        {
            int _result;
            _result = Random.Range(rockSpawnChance, _allChance);
                if (rockSpawnChance + enemySpawnChance > _result) return 1;
            else return 2;
        }
        int RandomNumberToSwitchNumberWithSpecialRocks()

        {
            int _result;
            _result = Random.Range(0, _allChance);
            if (rockSpawnChance > _result) return 3;
            if (rockSpawnChance + enemySpawnChance > _result) return 1;
            else return 2;
        }
        int RandomNumberToSwitchNumberNormal()
        {
            int _result;
            _result = Random.Range(0, _allChance);
            if (rockSpawnChance > _result) return 0;
            if (rockSpawnChance + enemySpawnChance > _result) return 1;
            else return 2;
        }
        void SwitchWhatLayerSpawn()
        {
            switch (_switchCase)
            {
                case 0:
                     _insideRocksCreator.CreateInsideRocks();
                     _sideRockCreator.CreateSideRocks();
                    _outsideRockCreator.CreateOutsideRocks();
                    break;
                case 1:
                    _creatorEnemySpawner.CreateEnemySpawner();
                    break;
                case 2:
                   _sideRockCreator.CreateSideRocks();
                    _outsideRockCreator.CreateOutsideRocks();
                    break;
                case 3:
                    _specialInsideRocksCreator.CreateSpecialInsideRocks();
                    _sideRockCreator.CreateSideRocks();
                    _outsideRockCreator.CreateOutsideRocks();
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