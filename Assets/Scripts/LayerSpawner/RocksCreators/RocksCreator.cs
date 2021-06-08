using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{
    public class RocksCreator : MonoBehaviour
    {
        [SerializeField, Tooltip("Distance Beetwen Side Rokcs And Middle")] public float distance;

        public GameObject InstantiateRandomRock()
        {
            GameObject _rock = Instantiate(ObstacleListScript.obstacleList[Random.Range(0, 9)]);
            _rock.transform.rotation = Quaternion.Euler( new Vector3(-90, _rock.transform.rotation.z, RandomRotation())); 
            return _rock; 
        }
        float RandomRotation()
        {
            float _rotation = Random.Range(0, 4) * 90;
            return _rotation;
            
        }

    }
}