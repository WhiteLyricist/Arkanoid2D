using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _bonusPrefab;

    private GameObject _bonus;

    public static Action OnBlockDestroy = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnBlockDestroy();
        BonusDrop();
        Destroy(this.gameObject);
    }

    private void BonusDrop()
    {
        var probability = UnityEngine.Random.Range(0, 101);

        if (0 <= probability && probability <= 70) 
        {
            return;
        }
        if (70 < probability && probability <= 80)
        {
            Drop(0);
            return;
        }
        if (80 < probability && probability <= 90)
        {
            Drop(1);
            return;
        }
        if (90 < probability && probability <= 100)
        {
            Drop(2);
            return;
        }
    }

    private void Drop(int i) 
    {
        _bonus = Instantiate(_bonusPrefab[i]);
        _bonus.transform.position = transform.position;
    }
}
