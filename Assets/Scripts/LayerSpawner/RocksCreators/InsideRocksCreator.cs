using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class RockGeneratorOutput
    {
        public IEnumerable<bool> RockSpawnFlags => ShouldSpawnRocksRow;
        private List<bool> ShouldSpawnRocksRow = new List<bool>();

        public void Add(bool SpawnChance)
        {
            ShouldSpawnRocksRow.Add(SpawnChance);
        }
    }

    public class InsideRocksCreator : RocksCreator
    {
        [SerializeField, Tooltip("Chance to spawn rock 1:yournumber")] int _rockChance;
        public void CreateInsideRocks()
        {
            const int SpawnPointOffsetAfterSpawn = 2;

            float _spawnPoint = -Distance + SpawnPointOffsetAfterSpawn;
            RockGeneratorOutput _listNumbers = ListWithRandomNumersToRandomRocks();
            //Spawn random rocks

            foreach (var shouldSpawn in _listNumbers.RockSpawnFlags)
            {
                if (!shouldSpawn)
                    return;

                GameObject _rock = InstantiateRandomRock();
                _rock.transform.position = transform.position + new Vector3(_spawnPoint, 0.0f, 0.0f);

                _spawnPoint += SpawnPointOffsetAfterSpawn;
            }
        }

        // Prepear list to spawn rocks
        RockGeneratorOutput ListWithRandomNumersToRandomRocks()
        {
            int _fullRockCheck = 0;
            RockGeneratorOutput RandomNumersForRocks = new RockGeneratorOutput();

            // Make sure there is one empty square
            var randomOpenSquareIndex = GetRandomOpenSquareIndex();

            for (int i = 0; i < Distance - 1; i++)
            {
                if (randomOpenSquareIndex == i)
                    RandomNumersForRocks.Add(false);

                if (ShouldLeaveOpenSquareRandom())
                    RandomNumersForRocks.Add(false);
                else
                {
                    RandomNumersForRocks.Add(true);
                    _fullRockCheck += 1;
                }
            }

            return RandomNumersForRocks;
        }

        private bool ShouldLeaveOpenSquareRandom()
        {
            return Random.Range(0, _rockChance + 1) == 0;
        }

        private int GetRandomOpenSquareIndex()
        {
            return Random.Range(0, (int)Distance - 1);
        }
    }
}