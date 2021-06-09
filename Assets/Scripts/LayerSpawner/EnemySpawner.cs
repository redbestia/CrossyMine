using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class EnemySpawner : MonoBehaviour
{
    int _randomNumber;
    GameObject _enemy;
    public void SpawnEnemy()
    {
        CrerteRandomNumber();
        EnemyInstantiate();
        RandomizeEnemyDirection();
    }

    void CrerteRandomNumber()
    {
        _randomNumber = Random.Range(0, EnemyListScript.enemyList.Count);
    }
    void EnemyInstantiate()
    {
        _enemy = Instantiate(EnemyListScript.enemyList[_randomNumber]);
        _enemy.transform.position += new Vector3(0, 0, transform.position.z);
    }
    void RandomizeEnemyDirection()
    {
        EnemyMovement _enemyMovement = _enemy.GetComponent<EnemyMovement>();
        _enemyMovement._topOrDown = (0 == Random.Range(0, 2));
    }
}
