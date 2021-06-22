using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCamera : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, speed);
    }
}
