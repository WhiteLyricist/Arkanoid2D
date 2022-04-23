using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveRacquets : MonoBehaviour
{

    [SerializeField] 
    private GameObject _bot;

    private Vector3 _touch;
    private float _touchX = 0f;

    private float _speed = 10f;

    private float _direction;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch tab = Input.GetTouch(0);
            if (tab.phase == TouchPhase.Moved)
            {
                _touch = tab.position;
                _touch = Camera.main.ScreenToWorldPoint(_touch);
                _direction = 3f * Mathf.Abs(_touch.x) / _touch.x;
                if (_touch.x > _touchX)
                {
                    _direction = 1f;
                }
                else
                {
                    _direction = -1f;
                }
                _touchX = _touch.x;
                _bot.GetComponent<Rigidbody2D>().velocity = new Vector2(_direction * _speed, 0);
            }
            else
            {
                _bot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        }
    }

}
