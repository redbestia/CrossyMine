using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class OnSpawnEvent : MonoBehaviour
    {
        public GameObject tracks;
        public bool spawnTracks;
        [SerializeField, Tooltip("Minimum number of spawned enemies")] public int minSpawn;
        [SerializeField, Tooltip("Maximum number of spawned enemies")] public int maxSpawn;
        [SerializeField, Tooltip("Minimum distance between spawn points")] public float minDistance;
        [SerializeField, Tooltip("Maximum distance between spawn points")] public float maxDistance;

        public void SpawnEvent(GameObject _enemy, EnemyMovement _enemyMovment)
        {
            if (spawnTracks)
            {
                GameObject _tracks = Instantiate(tracks);
                _tracks.transform.position += new Vector3(0, 0, _enemy.transform.position.z);
            }
            int RandomNumberSpawns = Random.Range(minSpawn, maxSpawn);
            float RandomNumberDistance = 0.0f;
            for (int i = 0; i < RandomNumberSpawns; i++)
            {
                RandomNumberDistance += Random.Range(minDistance, maxDistance);
                GameObject _newenemy = Instantiate(_enemy);
                _newenemy.transform.position += new Vector3(RandomNumberDistance, 0.0f, 0.0f);
            }

        }
    }
}