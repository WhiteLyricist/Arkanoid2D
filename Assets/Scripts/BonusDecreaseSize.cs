using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDecreaseSize : Bonus
{
    public override void GetBonus(Transform platform)
    {
        platform.localScale = new Vector2(Mathf.Max(0.25f, platform.localScale.x / 2), Mathf.Max(0.25f, platform.localScale.y / 2));
        Destroy(gameObject);
    }
}
