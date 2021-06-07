using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{
    public class RocksCreator : MonoBehaviour
    {
        [SerializeField, Tooltip("Distance Beetwen Side Rokcs And Middle")] private float distance;
        public void CreateSideRocks()
        {
            GameObject _leftRock = InstantiateRandomRock();
            _leftRock.transform.position = transform.position + new Vector3(-distance, transform.position.y, 0.0f);
            GameObject _rightRock = InstantiateRandomRock();
            _rightRock.transform.position = transform.position + new Vector3(distance, transform.position.y, 0.0f);
        }

        GameObject InstantiateRandomRock()
        {
            GameObject _rock = Instantiate(ObstacleListScript.obstacleList[Random.Range(0, 8)]);
            _rock.transform.rotation = Quaternion.Euler( new Vector3(-90, _rock.transform.rotation.z, RandomRotation())); 
            return _rock; 
        }
        float RandomRotation()
        {
            float _rotation = (float)Random.Range(0, 3) * 90;
            return _rotation;
            
        }

    }
}