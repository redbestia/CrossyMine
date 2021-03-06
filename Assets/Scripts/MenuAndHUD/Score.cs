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
        _player = GameObject.FindWithTag(Constants.PlayerTag);
    }
    void Update()
    {
        GetScoreDisplayIt();
    }

    void GetScoreDisplayIt()
    {
        _textMeshProUGUI.text = "Score: "
            + ((((int)_player.transform.position.z) / (int)Constants.GridSize) 
            - (int)Constants.GridSize).ToString();
    }
}
