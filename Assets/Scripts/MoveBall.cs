using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBall : MonoBehaviour
{
    private float _deltaX;
    private float _deltaY;

    private float _force;

    private const float direction = 1.0f;

    private Vector3 InitialVector;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _force = 200f;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _deltaX = UnityEngine.Random.Range(direction / 2, direction);
        _deltaY = UnityEngine.Random.Range(direction / 2, direction);

        InitialVector = new Vector2(_deltaX, _deltaY);
        _rigidbody2D.AddForce(InitialVector * _force);
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.x == 0) 
        {
            _rigidbody2D.velocity = new Vector2(3f, _rigidbody2D.velocity.y);
        }
        if (_rigidbody2D.velocity.y == 0) 
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 3f);
        }
    }

}
