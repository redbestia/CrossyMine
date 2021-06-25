using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Camera", menuName = "CameraAll")]
public class MoveingCameraAll : CameraMovmentStrategy
{
    public override void MoveCamera()
    {
        camera.transform.position = player.transform.position - new Vector3(0,-20,10);
    }
}
