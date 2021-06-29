using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
public class CreatorDontDestroyOnLoadGameObjects : MonoBehaviour
{
    [SerializeField, Tooltip("List of GameObjects thats will be not destroy with scene")] 
    List<GameObject> _gameObjectList;
    private void Awake()
    {
        for (int i = 0; i < _gameObjectList.Count; i++)
        {
            GameObject _gameObjectToCreate = _gameObjectList[i];

            if (!GameObject.FindGameObjectWithTag(_gameObjectList[i].tag))
            {
                _gameObjectToCreate = Instantiate(_gameObjectList[i]);
                DontDestroyOnLoad(_gameObjectToCreate);
            }
        }
    }
}
