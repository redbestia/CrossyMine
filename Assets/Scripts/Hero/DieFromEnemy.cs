using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class DieFromEnemy : Die
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Constants.EnemyTag)
        {
            PlayerDied();
        }
    } 
}
