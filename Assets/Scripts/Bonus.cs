using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        GetBonus(collision.transform);
    }

    public abstract void GetBonus(Transform platform); 

}
