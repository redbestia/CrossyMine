using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class OutsideRockCreator : RocksCreator
{
    public void CreateOutsideRocks()
    {
        for (float i = distance + 2; i < distance +  18; i+=2)
        {
            GameObject rock = InstantiateRandomRock();
            rock.transform.position = transform.position + new Vector3(i, 0, 0);
        }
        for (float i = -(distance + 2); i > -(distance + 18); i += -2)
        {
            GameObject rock = InstantiateRandomRock();
            rock.transform.position = transform.position + new Vector3(i, 0, 0);
        }
    }
}
