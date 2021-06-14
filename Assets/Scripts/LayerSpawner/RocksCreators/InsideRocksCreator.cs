using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class InsideRocksCreator : RocksCreator
    {
        [SerializeField,Tooltip("Chance to spawn rock 1:yournumber")] int _rockChance;
        public void CreateInsideRocks()
        {
            float _spawnPoint = -distance+2;
            List<int> _listNumbers = ListWithRandomNumersToRandomRocks();
            for (int i = 0; i < distance - 1; i++)
            {
                if(_listNumbers[i]==1)
                {
                    GameObject _rock = InstantiateRandomRock();
                    _rock.transform.position = transform.position + new Vector3(_spawnPoint, 0.0f, 0.0f);
                }
                _spawnPoint += 2;
            }

        }
        List<int> ListWithRandomNumersToRandomRocks()
        {
            int _fullRockCheck = 0;
            List<int> RandomNumersForRocks = new List<int>();
            for (int i = 0; i < distance - 1; i++)
            {
                if (Random.Range(0, _rockChance+1) == 0) RandomNumersForRocks.Add(0);
                else
                {
                    RandomNumersForRocks.Add(1);
                    _fullRockCheck += 1;
                }
            }
            if (_fullRockCheck == 7) RandomNumersForRocks[Random.Range(0,  (int)distance-1)] = 0;
            return RandomNumersForRocks;
        }
        
    }
}