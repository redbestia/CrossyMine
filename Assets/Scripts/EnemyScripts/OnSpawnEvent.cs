using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class OnSpawnEvent : MonoBehaviour
    {
        public GameObject tracks;
        public bool spawnTracks;

        public void SpawnEvent(GameObject _enemy)
        {
            if (spawnTracks)
            {
                GameObject _tracks = Instantiate(tracks);
                _tracks.transform.position += new Vector3(0, 0, _enemy.transform.position.z);
            }
        }
    }
}