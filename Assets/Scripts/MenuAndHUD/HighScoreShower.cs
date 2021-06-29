using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CrossyMine;
using TMPro;
using System;

public class HighScoreShower : MonoBehaviour
{
    public string topText;
    public int howMuchTopScoresShow;

    string _scoreBoard = "";

    private void Start()
    {
        ShowHighScore();
    }

    void ShowHighScore()
    {
        //Check and Create File
        StreamWriter _sw;
        if (!File.Exists(Constants.scoreBoardFileName)) _sw = File.CreateText(Constants.scoreBoardFileName);
        else _sw = new StreamWriter(Constants.scoreBoardFileName, true);
        _sw.Close();

        //Open file and prepear List
        StreamReader _sr = File.OpenText(Constants.scoreBoardFileName);
        string _scoreHolder;
        List<int> _scoreBoardList = new List<int>();
        while ((_scoreHolder = _sr.ReadLine()) != null)
        {
            _scoreBoardList.Add(Convert.ToInt32(_scoreHolder));
        }
        _scoreBoardList.Sort();
        _scoreBoardList.Reverse();

        //Display High Scores
        _scoreBoard += topText + "\n" ;
        if(howMuchTopScoresShow>_scoreBoardList.Count)
            for (int i = 0; i < _scoreBoardList.Count; i++)
            {
                _scoreBoard += (i + 1) + ". " + _scoreBoardList[i] + "\n";
            }
        else
            for (int i = 0; i < howMuchTopScoresShow; i++)
            {
                 _scoreBoard +=(i+1) + ". " + _scoreBoardList[i] + "\n";
            }
        GetComponent<TextMeshProUGUI>().text = _scoreBoard;
        _sr.Close();
        
    }
}
