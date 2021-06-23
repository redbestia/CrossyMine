using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class EnemySpawner : MonoBehaviour
{
    GameObject _enemy;
    int _randomNumber;
    EnemyMovement _enemyMovement;
    public void SpawnEnemy()
    {
        CrerteRandomNumber();
        EnemyInstantiate();
        RandomizeEnemyAndSpeedDirection();
        SpecialEventOnSpawn();
    }

    void CrerteRandomNumber()
    {
        _randomNumber = Random.Range(0, EnemyListScript.enemyList.Count);
    }
    void EnemyInstantiate()
    {
        _enemy = Instantiate(EnemyListScript.enemyList[_randomNumber]);
        _enemy.transform.position += new Vector3(Random.Range(-20,-10), 0, transform.position.z);
    }
    void RandomizeEnemyAndSpeedDirection()
    {
        _enemyMovement = _enemy.GetComponent<EnemyMovement>();
        _enemyMovement._topOrDown = (0 == Random.Range(0, 2));
        _enemyMovement.speed = Random.Range(_enemyMovement.minEnemySpeed, _enemyMovement.maxEnemySpeed +1);
    }
    void SpecialEventOnSpawn()
    {
        _enemyMovement = _enemy.GetComponent<EnemyMovement>();
        OnSpawnEvent enemySpawn = _enemy.GetComponent<OnSpawnEvent>();
        enemySpawn.SpawnEvent(_enemy, _enemyMovement);
    }
   
}
