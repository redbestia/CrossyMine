using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

namespace CrossyOwl
{
    /// <summary>
    /// Grid movement player controller 
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Events
        public event Action Jump;
        public event Action Obstacle;
        #endregion

        /// <summary>
        /// Force magnitude applied to the vertical movement
        /// </summary>
        [SerializeField, Tooltip("Jump height")]
        float _verticalJumpForce = 1f;

        /// <summary>
        /// Horizontal movement speed - has to be .
        /// hand-tuned to match the vertical speed
        /// TODO: Extend the jumping mechanics by programmatic horizontalSpeed calculation
        /// </summary>
        [SerializeField, Tooltip("Horizontal speed")]
        float _horizontalSpeed = 1f;

        Vector3Int _inputDir = Vector3Int.zero;
        bool _isJumping;
        Vector3 _nextPos;
        Vector3 _prevPos;
        Rigidbody _rigidBody;

        #region Monobehaviour
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Get user input - has to happen in Update
            if (Input.GetKey(KeyCode.UpArrow)) _inputDir = new Vector3Int(0, 0, 1);
            else if (Input.GetKey(KeyCode.DownArrow)) _inputDir = new Vector3Int(0,0,-1);
            else if (Input.GetKey(KeyCode.RightArrow)) _inputDir = new Vector3Int(1, 0, 0);
            else if (Input.GetKey(KeyCode.LeftArrow)) _inputDir = new Vector3Int(-1, 0, 0);
            else _inputDir = Vector3Int.zero;
            
        }

        private void FixedUpdate()
        {
            if (_isJumping)
            {
                InterpolateHorizontal();

                if (_rigidBody.velocity.magnitude <= 0.01f)
                {
                    _isJumping = false;
                    _rigidBody.position = _nextPos;
                }
            }
            if (!_isJumping && _inputDir != Vector3Int.zero)
            {
                StartMove(_inputDir);
                _inputDir = Vector3Int.zero;
                if (Jump != null) Jump();
            }
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == GameSettings.Instance.ObstacleTag ||
        //        collision.gameObject.transform.parent.tag == GameSettings.Instance.ObstacleTag)
        //    {
        //        Debug.Log("Hit Obstacle!");
        //        ReflectJump();
        //        if (Obstacle != null) Obstacle();
        //    }
        //}
        #endregion

        /// <summary>
        /// Interpolates the horizontal x,z position during jump
        /// </summary>
        private void InterpolateHorizontal()
        {
            _nextPos.y = _rigidBody.position.y;
            var lerp = Vector3.Lerp(_rigidBody.position, _nextPos, _horizontalSpeed * Time.deltaTime);
            _rigidBody.position = lerp;
        }

        /// <summary>
        /// Uses physics engine for vertical movement and simple lerping for horizontal.
        /// </summary>
        /// <param name="direction">Direction to move in</param>
        private void StartMove(Vector3 direction)
        {
            //Vertical movement
            _rigidBody.AddForce(0f, _verticalJumpForce, 0f);

            //Horizontal movemement
            Vector3 currentPos = _rigidBody.position;
            _nextPos = currentPos + direction * GameSettings.Instance.GridSize;

            _isJumping = true;

            //Cache the currentPos, in case we need to go back
            _prevPos = currentPos;
        }

        private void ReflectJump()
        {
            //Vertical movement
            _rigidBody.AddForce(0f, _verticalJumpForce / 4.0f, 0f);
            _nextPos = _prevPos;
        }
    }
}