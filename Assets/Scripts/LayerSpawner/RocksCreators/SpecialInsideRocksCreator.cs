using CrossyMine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInsideRocksCreator : RocksCreator
{
    public void CreateSpecialInsideRocks()
    {
        for (float i = -distance+4 ; i < distance-2; i = i+2)
        {
            GameObject _insiderock = InstantiateRandomRock();
            _insiderock.transform.position = transform.position + new Vector3(i, 0, 0); 
        }
    }
}
