using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFormTransform : Die
{

    private void Update()
    {
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            PlayerDied();
        }
    }
}
