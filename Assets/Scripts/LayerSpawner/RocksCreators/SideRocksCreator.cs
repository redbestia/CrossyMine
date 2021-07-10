
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

namespace CrossyMine
{
    public class SideRocksCreator : RocksCreator
    {
        public void CreateSideRocks()
        {
            GameObject _leftRock = InstantiateRandomRock();
            _leftRock.transform.position = transform.position + new Vector3(-DistanceFromMidToSideRock, 0.0f  , 0.0f);

            GameObject _rightRock = InstantiateRandomRock();
            _rightRock.transform.position = transform.position + new Vector3(DistanceFromMidToSideRock, 0.0f, 0.0f);
        }
    }
}