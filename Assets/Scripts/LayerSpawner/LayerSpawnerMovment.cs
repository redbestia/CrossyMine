using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{

    public enum LayerType
    {
        SideRocks,
        InsideRocks,
        SpecialRocks,
        EnemyField
    }

    public class LayerSpawnerMovment : MonoBehaviour
    {
        private const int SafeStartLeanght = 6;
        [SerializeField, Tooltip("Reference Camera")] private GameObject _camera;
        Vector3 _moveVector = new Vector3(0.0f, 0.0f, Constants.GridSize);
        public float _difBetwenSpawnerAndCamera;
        SideRocksCreator _sideRockCreator;
        InsideRocksCreator _insideRocksCreator;
        OutsideRockCreator _outsideRockCreator;
        SpecialInsideRocksCreator _specialInsideRocksCreator;
        CreatorEnemySpawner _creatorEnemySpawner;
        SpawnerProceduralGenerationRandomizer _randomizer;
        int _layerCounter = 1;
        LayerType _switchCase;
        LayerType _previousSwitchCase;

        #region MonoBehaviour
        private void Awake()
        {
            _sideRockCreator = GetComponent<SideRocksCreator>();
            _insideRocksCreator = GetComponent<InsideRocksCreator>();
            _specialInsideRocksCreator = GetComponent<SpecialInsideRocksCreator>();
            _outsideRockCreator = GetComponent<OutsideRockCreator>();
            _creatorEnemySpawner = GetComponent<CreatorEnemySpawner>();
            _randomizer = GetComponent<SpawnerProceduralGenerationRandomizer>();
        }
        private void Update()
        {
            SpawnMoveSpawner();
        }
        #endregion

        void SpawnMoveSpawner()
        {
            bool ShouldJumpSpawnerAsCameraApproaches =
                transform.position.z < _camera.transform.position.z 
                + _difBetwenSpawnerAndCamera ;

            if (ShouldJumpSpawnerAsCameraApproaches)
            {
                _randomizer.SumAllChance();
                SafeStartOrNoramlSpawn();
                SwitchWhatLayerSpawn();
                AddToLayerCounter();
                MoveSpawnerForward();
            }
        }

        void SafeStartOrNoramlSpawn()
        {
            if (_layerCounter <= SafeStartLeanght)
            {
                _switchCase = LayerType.SideRocks;
                return;
            }

            if (_switchCase == LayerType.InsideRocks | _switchCase 
                == LayerType.SpecialRocks)
            {
                _previousSwitchCase = _switchCase;
                _switchCase = _randomizer
                    .RandomNumberToSwitchNumberWithoutInsideRocks();
            }
            else if (_switchCase == LayerType.EnemyField 
                     & _previousSwitchCase == LayerType.InsideRocks ||
                     _switchCase == LayerType.EnemyField
                     & _previousSwitchCase == LayerType.SpecialRocks)
            {
                _previousSwitchCase = _switchCase;
                _switchCase = _randomizer
                    .RandomNumberToSwitchNumberWithSpecialRocks();
            }
            else
            {
                _previousSwitchCase = _switchCase;
                _switchCase = _randomizer.RandomNumberToSwitchNumberNormal();
            }
        }

        void SwitchWhatLayerSpawn()
        {
            switch (_switchCase)
            {
                case LayerType.InsideRocks:
                    _insideRocksCreator.CreateInsideRocks();
                    _sideRockCreator.CreateSideRocks();
                    //_outsideRockCreator.CreateOutsideRocks();
                    break;
                case LayerType.EnemyField:
                    _creatorEnemySpawner.CreateEnemySpawner();
                    break;
                case LayerType.SideRocks:
                    _sideRockCreator.CreateSideRocks();
                    //_outsideRockCreator.CreateOutsideRocks();
                    break;
                case LayerType.SpecialRocks:
                    _specialInsideRocksCreator.CreateSpecialInsideRocks();
                    _sideRockCreator.CreateSideRocks();
                    //_outsideRockCreator.CreateOutsideRocks();
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