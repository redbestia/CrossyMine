using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;

public class AudioHolderTime : MonoBehaviour
{
    GameObject _camera;
    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag(Constants.MainCameraTag);
    }
}
