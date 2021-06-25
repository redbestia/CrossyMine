using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Camera", menuName = "CameraZ")]
public class MovingCameraZ : CameraMovmentStrategy
{
    public override void MoveCamera()
    {
        camera.transform.position = new Vector3 (0,20, player.transform.position.z-10) ;
    }
}
