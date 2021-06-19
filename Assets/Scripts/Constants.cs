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
        public const string mainCameraTag= "MainCamera";
        public const string diedMenuTag = "DiedMenu";
        public const string startMenuTag = "StartMenu";
        public const string pauseMenuTag = "PauseMenu";
        public const string pauseButtonTag = "PauseButton";
        public const string audioHolder = "AudioHolder";
        
        #endregion

        #region Script Tags
        public const string mineCartTag = "MineCartSpawn";
        public const string monsterTag = "MonsterSpawn";
        public const string rollingRockTag = "RollingRockSpawn";

        #endregion

        #region FileNames
        public const string scoreBoardFileName = "ScoreBoard.txt";
        #endregion
    }
}