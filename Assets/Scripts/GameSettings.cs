using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class holding the game tuning properties
/// </summary>
public class GameSettings : MonoBehaviour
{
    /// <summary>
    /// Singleton implementation
    /// </summary>
    public static GameSettings Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                _instance = Camera.main.gameObject.AddComponent<GameSettings>();
            }
            return _instance;
        }
    }
    static GameSettings _instance;

    public readonly float GridSize = 2f;
    public readonly string ObstacleTag = "Obstacle";
}
