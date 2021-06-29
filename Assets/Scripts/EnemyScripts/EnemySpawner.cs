using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class EnemySpawner : MonoBehaviour
{
    GameObject _enemy;
    GameObject _enemyToInstantite;
    EnemyMovement _enemyMovement;
    float _randomDistance;
    int _randomNumber;
    float _sumRnadomDistance =0;

    #region MonoBehaviour
    private void Start()
    {
        SpawnEnemy();
        SpecialEventOnSpawn();
        SawnMoreOnStart();
    }

    private void Update()
    {
        CheckPositionAndSpawn();
    }
    #endregion

    void CheckPositionAndSpawn()
    {
         if (! (_enemy == null))
        {
            if (_enemy.transform.position.x > -(_enemyMovement.spawnPoint - _randomDistance) && _enemy.transform.position.x<_enemyMovement.spawnPoint - _randomDistance)
            {
                SpawntTheSameEnemy();
                 _randomDistance = RandomDistance();
            }
        }
    }

    void SawnMoreOnStart()
    {
        _randomDistance = RandomDistance();
        _enemyToInstantite = Instantiate(_enemy);
        _enemy.SetActive(true);
        while (_enemyMovement.spawnPoint * 2 > _sumRnadomDistance)
        {
            _randomDistance = RandomDistance();
            _sumRnadomDistance += _randomDistance;
            if (_enemyMovement.spawnPoint * 2 > _sumRnadomDistance)
            {
                GameObject enemy = Instantiate(_enemyToInstantite);
                if (_enemyMovement._topOrDown) enemy.transform.position -= new Vector3(_sumRnadomDistance, 0, 0);
                else enemy.transform.position += new Vector3(_sumRnadomDistance, 0, 0);
                enemy.SetActive(true);
            }
        }
    }
    void SpawntTheSameEnemy()
    {
        _enemy = Instantiate(_enemyToInstantite);
        _enemy.SetActive(true);

    }
    void SpawnEnemy()
    {
        CrerteRandomNumber();
        EnemyInstantiate();
        RandomizeEnemySpeed();
    }

    void CrerteRandomNumber()
    {
        _randomNumber = Random.Range(0, EnemyListScript.enemyList.Count);
    }
    void EnemyInstantiate()
    {
        _enemy = Instantiate(EnemyListScript.enemyList[_randomNumber]);
        _enemyMovement = _enemy.GetComponent<EnemyMovement>();
        _enemyMovement._topOrDown = (0 == Random.Range(0, 2));
        _enemyMovement.ChooseDirecrionRotate();
        if (_enemyMovement._topOrDown) _enemy.transform.position += new Vector3(_enemyMovement.spawnPoint, 0, transform.position.z);
        else _enemy.transform.position += new Vector3(-_enemyMovement.spawnPoint, 0, transform.position.z);
    }
    void RandomizeEnemySpeed()
    {
        
        _enemyMovement.speed = Random.Range(_enemyMovement.minEnemySpeed, _enemyMovement.maxEnemySpeed +1);
        _enemy.SetActive(false);
        
    }
    void SpecialEventOnSpawn()
    {
        _enemyMovement = _enemy.GetComponent<EnemyMovement>();
        OnSpawnEvent onSpawnEvent = _enemy.GetComponent<OnSpawnEvent>();
        onSpawnEvent.SpawnEvent(_enemy);
    }
    float RandomDistance()
    {
        float randomDistance;
        randomDistance = Random.Range(_enemy.GetComponent<EnemyMovement>().minDistanc, _enemy.GetComponent<EnemyMovement>().maxDistanc);
        return randomDistance;
    }
}
