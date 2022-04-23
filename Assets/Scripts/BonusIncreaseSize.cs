using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusIncreaseSize : Bonus
{
    public override void GetBonus(Transform platform)
    {
        platform.localScale = new Vector2(Mathf.Min(1f, platform.localScale.x * 2), Mathf.Min(1f, platform.localScale.y * 2));
        Destroy(gameObject);
    }
}
