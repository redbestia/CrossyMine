using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyerDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
