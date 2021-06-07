using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class ObstacleListScript : MonoBehaviour
    {
        public List<GameObject> _obstacleListToStatic;
        public static List<GameObject> obstacleList;
            private void Awake()
        {
            obstacleList = _obstacleListToStatic;
        }
    }
}