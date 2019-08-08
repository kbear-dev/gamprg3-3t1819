using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuff : Buff
{
    public int HealValue;
    public float duration;

    Health hp;
    public override IEnumerator Effect()
    {
        hp = Target.GetComponent<Health>();
        hp.Heal(HealValue);
        yield return null;
        hp.isShielded = true;
        hp.ShieldSprite.SetActive(true);

        for(int x = 0; x < duration; x++)
        {
            if (!hp.isShielded)
                break;
            yield return new WaitForSeconds(1.0f);
        }

        buffEnded.Invoke(this);
    }

    protected override IEnumerator Cleanup()
    {
        if (hp.isShielded)
            hp.isShielded = false;

        if (hp.ShieldSprite.activeSelf)
            hp.ShieldSprite.SetActive(false);

        yield return null;
    }
}
