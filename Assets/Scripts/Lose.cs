using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public static Action OnLose = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnLose();
    }
}
