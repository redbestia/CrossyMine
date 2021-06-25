using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorEnemySpawner : MonoBehaviour
{
    public GameObject enemySpawner;
    public void CreateEnemySpawner()
    {
            GameObject enemySpawnerCopy = Instantiate(enemySpawner);
            enemySpawnerCopy.transform.position = transform.position;
    }
}
