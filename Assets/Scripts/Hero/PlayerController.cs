using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

namespace CrossyMine
{
    public class PlayerController : MonoBehaviour
    {
        #region Events
        public event Action Jump;
        public event Action Obstacle;
        #endregion

       
        [SerializeField, Tooltip("How high player will jump")] float _jumpForce = 1f;

        [SerializeField, Tooltip("Forward speed")] float _forwardSpeed = 1f;

        [SerializeField, Tooltip("Size of one squer in game")] float GridSize = 2f;

        Vector3Int _inputDir = Vector3Int.zero;
        bool _isJumping;
        Vector3 _nextPos;
        Vector3 _prevPos;
        Rigidbody _rigidBody;

        #region Monobehaviour
        private void Awake() // Get Rigidbody
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update() //Get user input
        {
           
            if (Input.GetKey(KeyCode.UpArrow)) _inputDir = new Vector3Int(0, 0, 1);
            else if (Input.GetKey(KeyCode.DownArrow)) _inputDir = new Vector3Int(0,0,-1);
            else if (Input.GetKey(KeyCode.RightArrow)) _inputDir = new Vector3Int(1, 0, 0);
            else if (Input.GetKey(KeyCode.LeftArrow)) _inputDir = new Vector3Int(-1, 0, 0);
            else _inputDir = Vector3Int.zero;
            
        }

        private void FixedUpdate()//Jumping 
        {
            if (_isJumping)
            {
                InterpolateHorizontal();

                if (_rigidBody.velocity.magnitude <= 0.01f) //Jump checker
                {
                    _isJumping = false;
                    _rigidBody.position = _nextPos;
                }
            }
            if (!_isJumping && _inputDir != Vector3Int.zero)//Jump if input
            {
                StartMove(_inputDir);
                _inputDir = Vector3Int.zero;
                if (Jump != null) Jump();
            }
        }

        private void OnCollisionEnter(Collision collision)// Obstacle hit
        {
            if (collision.gameObject.tag == Constants.obstacleTag)
            {
                ReflectJump();
                if (Obstacle != null) Obstacle();
            }
        }
        #endregion
        private void InterpolateHorizontal() // Interpolates the horizontal x,z position during jump
        {
            _nextPos.y = _rigidBody.position.y;
            var lerp = Vector3.Lerp(_rigidBody.position, _nextPos, _forwardSpeed * Time.deltaTime);
            _rigidBody.position = lerp;
        }
        private void StartMove(Vector3 direction)// Movement
        {
            //Jump
            _rigidBody.AddForce(0f, _jumpForce, 0f);

            //Forward movemement
            Vector3 currentPos = _rigidBody.position;
            _nextPos = currentPos + direction * GridSize;

            _isJumping = true;

            //If hit obstacle back to _prevPos
            _prevPos = currentPos;
        }

        private void ReflectJump() // Back to _prevPos if Hit obstacle
        {
            _rigidBody.AddForce(0f, _jumpForce / 4.0f, 0f);
            _nextPos = _prevPos;
        }
    }
}