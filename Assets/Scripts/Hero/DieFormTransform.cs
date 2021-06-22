using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFormTransform : Die
{
    public int xPointWherePlayerWillDie;
    private void Update()
    {
        if (transform.position.x > xPointWherePlayerWillDie || transform.position.x < -xPointWherePlayerWillDie)
        {
            PlayerDied();
        }
    }
}
