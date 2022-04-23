using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : Bonus
{
    [SerializeField]
    private GameObject _bonusBallPrefab;

    private GameObject _bonusBall;

    public override void GetBonus(Transform platform)
    {
        _bonusBall = Instantiate(_bonusBallPrefab) as GameObject;
        _bonusBall.transform.position = transform.position;
        Destroy(gameObject);
    }

}
