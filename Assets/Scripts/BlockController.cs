using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public static Action OnBlockDestroy = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnBlockDestroy();
        Destroy(this.gameObject);
    }
}
