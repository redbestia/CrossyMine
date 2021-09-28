using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class Constants : MonoBehaviour
    {
        #region Unity Tags
        public const string EnemyTag = "Enemy";
        public const string ObstacleTag = "Obstacle";
        public const string PlayerTag = "Player";
        public const string FieldTag = "Field";
        public const string MainCameraTag= "MainCamera";
        public const string DiedMenuTag = "DiedMenu";
        public const string StartMenuTag = "StartMenu";
        public const string PauseMenuTag = "PauseMenu";
        public const string PauseButtonTag = "PauseButton";
        public const string AudioHolder = "AudioHolder";
        public const string EnemySpawnerTag = "EnmeySpawner";
        public const string StartButtonTag = "StartButton";
        public const string ButtonUpTag = "ButtonUP";
        public const string ButtonRightTag = "ButtonRight";
        public const string ButtonDownTag = "ButtonDown";
        public const string ButtonLeftTag = "ButtonLeft";


        #endregion

        #region Script Tags
        public const string MineCartTag = "MineCartSpawn";
        public const string MonsterTag = "MonsterSpawn";
        public const string RollingRockTag = "RollingRockSpawn";

        #endregion

        #region FileNames
        public const string ScoreBoardFileName = "ScoreBoard.txt";
        #endregion

        #region GameSettings
        public const float GridSize = 2;

        #endregion
        
    }
}