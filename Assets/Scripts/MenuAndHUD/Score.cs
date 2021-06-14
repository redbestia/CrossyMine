using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CrossyMine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI _textMeshProUGUI;
    GameObject _player;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _player = GameObject.FindWithTag(Constants.playerTag);
    }
    void Update()
    {
        GetScoreDisplayIt();
    }

    void GetScoreDisplayIt()
    {
        _textMeshProUGUI.text = "Score: " + ((((int)_player.transform.position.z) / 2) - 2).ToString();
    }
}
