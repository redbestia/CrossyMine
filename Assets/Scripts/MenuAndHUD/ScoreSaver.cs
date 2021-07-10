using CrossyMine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ScoreSaver : MonoBehaviour
{
    
    GameObject _player;

    private void Awake()
    { 
        _player = GameObject.FindWithTag(Constants.PlayerTag);
    }

    void SaveScore()
    {
        string _path= "ScoreBoard.txt";
        StreamWriter _sw;
        if (!File.Exists(_path)) _sw = File.CreateText(_path);
        else _sw = new StreamWriter(_path, true);
        _sw.WriteLine(((((int)_player.transform.position.z) / 2) - 2).ToString());
        _sw.Close();
    }
}
