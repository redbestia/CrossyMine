using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class InsideRockGeneratorOutput
    {
        public IEnumerable<bool> RockSpawnFlags => ShouldSpawnRocksRow;
        public List<bool> ShouldSpawnRocksRow = new List<bool>();

        public void Add(bool SpawnChance)
        {
            ShouldSpawnRocksRow.Add(SpawnChance);
        }
        public void RemoveOneRandomRock(int DistanceFromMidToSideRock)
        {
            ShouldSpawnRocksRow[Random.Range(0, DistanceFromMidToSideRock - 1)] = false;
        }
    }
}