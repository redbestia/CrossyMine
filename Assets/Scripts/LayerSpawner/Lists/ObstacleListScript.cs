using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossyMine
{
    public class ObstacleListScript : MonoBehaviour
    {
        public List<GameObject> obstacleListToStatic;
        public static List<GameObject> obstacleList;
            private void Awake()
        {
            obstacleList = obstacleListToStatic;
        }
    }
}