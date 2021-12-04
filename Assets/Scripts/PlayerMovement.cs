using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool Movable = true;
    
    private Vector3 _direction;
    
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
        _controller.Move(_direction * (_speed * Time.deltaTime));
    }

    void OnMove(InputValue value)
    {
        if (Movable)
            _direction = new Vector3(value.Get<Vector2>().x, 0f, value.Get<Vector2>().y);
    }
}
