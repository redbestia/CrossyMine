using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class OutsideRockCreator : RocksCreator
{
    public void CreateOutsideRocks()
    {
        const float _maxSpawnDistance = 9 * Constants.GridSize;

        for (float i = DistanceFromMidToSideRock + Constants.GridSize;
            i < DistanceFromMidToSideRock + _maxSpawnDistance;
            i += Constants.GridSize)
        {
            GameObject rock = InstantiateRandomRock();
            rock.transform.position = transform.position + new Vector3(i, 0, 0);
        }

        for (float i = -(DistanceFromMidToSideRock + Constants.GridSize);
            i > -(DistanceFromMidToSideRock + _maxSpawnDistance);
            i += -Constants.GridSize)
        {
            GameObject rock = InstantiateRandomRock();
            rock.transform.position = transform.position + new Vector3(i, 0, 0);
        }
    }
}