using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
//using System.IO;

public abstract class Die : MonoBehaviour
{
    PlayerController _playerController;
    Canvas _canvas;

    #region MonoBehaviour
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _canvas = GameObject.FindWithTag(Constants.DiedMenuTag).GetComponent<Canvas>();
    }
    #endregion

    public void PlayerDied()
    {
        //SaveScore();
        _canvas.enabled = true;
        GameObject.FindGameObjectWithTag(Constants.StartButtonTag).
            GetComponent<GameStarter>().enabled = false;
        _playerController.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().Sleep();
        GetComponent<DieFormTransform>().enabled = false;
        GetComponent<DieFromTooSlow>().enabled = false;
        transform.localScale = new Vector3 (transform.localScale.x, 0.1f, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        

    }

    //void SaveScore()
    //{
    //    StreamWriter _sw;
    //    if (!File.Exists(Constants.ScoreBoardFileName)) _sw = File.
    //            CreateText(Constants.ScoreBoardFileName);
    //    else _sw = new StreamWriter(Constants.ScoreBoardFileName, true);
    //    _sw.WriteLine(((((int)transform.position.z) / 2) - 2).ToString());
    //    _sw.Close();
    //}
}
