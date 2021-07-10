using CrossyMine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialInsideRocksCreator : RocksCreator
{
    public void CreateSpecialInsideRocks()
    {
        for (float i = -DistanceFromMidToSideRock + Constants.GridSize * 2 ; 
            i < DistanceFromMidToSideRock-Constants.GridSize; i = i+Constants.GridSize)
        {
            GameObject _insiderock = InstantiateRandomRock();
            _insiderock.transform.position = transform.position + new Vector3(i, 0, 0); 
        }
    }
}
