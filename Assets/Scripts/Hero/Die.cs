using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
using System.IO;

public class Die : MonoBehaviour
{
    PlayerController _playerController;
    Canvas _canvas;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _canvas = GameObject.FindWithTag(Constants.diedMenuTag).GetComponent<Canvas>();
    }
    public void PlayerDied()
    {
        SaveScore();
        _playerController.enabled = false;
        _canvas.enabled = true;
        GetComponent<DieFormTransform>().enabled = false;
        GetComponent<DieFromTooSlow>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    void SaveScore()
    {
        StreamWriter _sw;
        if (!File.Exists(Constants.scoreBoardFileName)) _sw = File.CreateText(Constants.scoreBoardFileName);
        else _sw = new StreamWriter(Constants.scoreBoardFileName, true);
        _sw.WriteLine(((((int)transform.position.z) / 2) - 2).ToString());
        _sw.Close();
    }
}
