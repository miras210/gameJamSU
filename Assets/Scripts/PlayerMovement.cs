using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool Movable = true;
    
    public Vector3 _direction;

    private Vector3 _velocity;

    private bool _isGrounded;
    
    public LayerMask Ground;
    
    public float GroundDistance = 0.2f;
    
    [SerializeField]
    private Transform _groundChecker;

    private const float _gravity = -9.81f;
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Movable)
        {
            _velocity.y += _gravity * Time.deltaTime;
            _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
            if (_isGrounded && _velocity.y < 0)
                _velocity.y = 0f;
        
            _controller.Move(_velocity * Time.deltaTime);
            _controller.Move(_direction * (_speed * Time.deltaTime));
        }
    }

    void OnMove(InputValue value)
    {
        _direction = new Vector3(value.Get<Vector2>().x, 0f, value.Get<Vector2>().y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(_groundChecker.position, GroundDistance);
    }
}
