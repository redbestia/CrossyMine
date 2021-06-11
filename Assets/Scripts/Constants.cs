using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class Constants : MonoBehaviour
    {
        #region Unity Tags
        public const string enemyTag = "Enemy";
        public const string obstacleTag = "Obstacle";
        public const string playerTag = "Player";
        public const string fieldTag = "Field";
        #endregion

        #region Script Tags
        public const string MineCartTag = "MineCartSpawn";
        public const string MonsterTag = "MonsterSpawn";
        public const string RollingRockTag = "RollingRockSpawn";

        #endregion
    }
}