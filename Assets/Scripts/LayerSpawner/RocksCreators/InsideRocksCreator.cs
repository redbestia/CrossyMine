using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class InsideRocksCreator : RocksCreator
    {
        [SerializeField, Tooltip("Chance to spawn rock 1:yournumber")] int _rockChance;
        public void CreateInsideRocks()
        {
            float _spawnPoint = -DistanceFromMidToSideRock + Constants.GridSize;
            InsideRockGeneratorOutput _listNumbers = ListWithRandomNumersToRandomRocks();
            //Spawn random rocks


            foreach (var shouldSpawn in _listNumbers.RockSpawnFlags)
            {
                if (shouldSpawn)
                {
                    GameObject _rock = InstantiateRandomRock();
                    _rock.transform.position = transform.position +
                        new Vector3(_spawnPoint, 0.0f, 0.0f);
                }

                _spawnPoint += Constants.GridSize;
                

            }
        }

        // Prepear list to spawn rocks
        InsideRockGeneratorOutput ListWithRandomNumersToRandomRocks()
        {
            int _fullRockCheck = 0;
            InsideRockGeneratorOutput RandomNumersForRocks = new InsideRockGeneratorOutput();

            

            for (int i = 0; i < DistanceFromMidToSideRock - 1; i++)
            {

                if (ShouldLeaveOpenSquareRandom())
                    RandomNumersForRocks.Add(false);
                else
                {
                    RandomNumersForRocks.Add(true);
                    _fullRockCheck += 1;
                }
            }

            // Make sure there is one empty square
            if (_fullRockCheck == DistanceFromMidToSideRock - 1)
            {
                RandomNumersForRocks.RemoveOneRandomRock((int)DistanceFromMidToSideRock);
            }
            return RandomNumersForRocks;
        }

        private bool ShouldLeaveOpenSquareRandom()
        {
            return Random.Range(0, _rockChance + 1) == 0;
        }

        private int GetRandomOpenSquareIndex()
        {
            return Random.Range(0, (int)DistanceFromMidToSideRock - 1);
        }

       
    }
}