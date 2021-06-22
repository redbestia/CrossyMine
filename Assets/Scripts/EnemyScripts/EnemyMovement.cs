using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Tooltip("EnemySpeed")] public float speed = 1f;
    [SerializeField, Tooltip("Max Point Top")] float _maxTop;
    [SerializeField, Tooltip("Max Point Down")] float _maxDown;
    [SerializeField, Tooltip("Yes =going top No= going down")] public bool _topOrDown; 
    public int minEnemySpeed;
    public int maxEnemySpeed;
    Rigidbody _rigidbody;
    #region MonoBehaviour
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ChooseDirecrion();
    }

    private void Update()
    {
        BackToStartIfRequired(); 
    }
    #endregion
    private void BackToStartIfRequired()
    {
        if (_topOrDown) BackToStartTop();
        else BackToStartDown();
    }    
    private void ChooseDirecrion()
    {
        if (_topOrDown) _rigidbody.AddForce(new Vector3(-1.0f * speed, 0, 0));
        else
        {
            if (transform.rotation.x > -0.1f) transform.Rotate(new Vector3(0, -180, 0));
            else transform.Rotate(new Vector3(0, 0, -180));

            _rigidbody.AddForce(new Vector3(1.0f * speed, 0, 0));
        }
    }
    private void BackToStartTop()
    {
        if (_maxTop >= transform.position.x)
            transform.position = new Vector3(_maxDown, transform.position.y, transform.position.z);
     
    }
    private void BackToStartDown()
    {
        if (_maxDown <= transform.position.x)
            transform.position = new Vector3(_maxTop, transform.position.y, transform.position.z);
    }
}
