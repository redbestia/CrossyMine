using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class EnemyListScript : MonoBehaviour
    {
        public List<GameObject> enemyListToStatic;
        public static List<GameObject> enemyList;

        private void Awake()
        {
            enemyList = enemyListToStatic;
        }

    }
}
