using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class CameraFirstTransform : MonoBehaviour
{
    private void Awake()
    {
       // transform.position = transform.position + new Vector3(0, 0, (GameObject.FindGameObjectWithTag(Constants.playerTag).transform.position.z - transform.position.z) / GetComponent<CameraMovment>().slowJumpCamera);
    }
}
