using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Tooltip("EnemySpeed")] public float speed = 1f;
    [SerializeField, Tooltip("Max Point Top")] public float spawnPoint;
    [SerializeField, Tooltip("Yes =going top No= going down")] public bool _topOrDown;
    [SerializeField, Tooltip("Minimum distance between enemies")] public float minDistanc;
    [SerializeField, Tooltip("!!!Must be less than SpawnPoint!!! Maximum sistance between enemies")] public float maxDistanc;
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
        ChooseDirectionForce();
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
    public void ChooseDirecrionRotate()
    {
        if (!_topOrDown)
        {
            if (transform.rotation.x > -0.1f) transform.Rotate(new Vector3(0, -180, 0));
            else transform.Rotate(new Vector3(0, 0, -180));
        }
    }
    public void ChooseDirectionForce()
    {
        if (_topOrDown) _rigidbody.AddForce(new Vector3(-1.0f * speed, 0, 0));
        else
        {
            _rigidbody.AddForce(new Vector3(1.0f * speed, 0, 0));
        }
    }
    private void BackToStartTop()
    {
        if (-spawnPoint >= transform.position.x) 
           Destroy(gameObject);
     
    }
    private void BackToStartDown()
    {
        if (spawnPoint <= transform.position.x) 
          Destroy(gameObject); ;
    }
}
