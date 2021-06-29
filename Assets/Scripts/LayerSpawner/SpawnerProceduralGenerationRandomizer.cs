using UnityEngine;

namespace CrossyMine
{
    public class SpawnerProceduralGenerationRandomizer : MonoBehaviour
    {
        public int rockSpawnChance;
        public int enemySpawnChance;
        public int noRockSpawnChance;

        int _allChance;

        //Extract to separate class
        public LayerType RandomNumberToSwitchNumberWithoutInsideRocks()
        {
            int _result;
            _result = Random.Range(rockSpawnChance, _allChance);
            if (rockSpawnChance + enemySpawnChance > _result) return LayerType.EnemyField;
            else return LayerType.SideRocks;
        }

        public LayerType RandomNumberToSwitchNumberWithSpecialRocks()
        {
            int result;
            result = Random.Range(0, _allChance);
            if (rockSpawnChance > result) return LayerType.SpecialRocks;
            if (rockSpawnChance + enemySpawnChance > result) return LayerType.EnemyField;
            else return LayerType.SideRocks;
        }

        public LayerType RandomNumberToSwitchNumberNormal()
        {
            int _result;
            _result = Random.Range(0, _allChance);
            if (rockSpawnChance > _result) return LayerType.InsideRocks;
            if (rockSpawnChance + enemySpawnChance > _result) return LayerType.EnemyField;
            else return LayerType.SideRocks;
        }

        public void SumAllChance()
        {
            _allChance = rockSpawnChance + noRockSpawnChance + enemySpawnChance;
        }
    }
}
