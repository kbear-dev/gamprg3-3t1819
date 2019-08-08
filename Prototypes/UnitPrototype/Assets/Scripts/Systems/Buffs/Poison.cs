using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Buff
{
    public int PoisonDamage;
    public int Duration;
    public float TickRate;
    public override IEnumerator Effect()
    {
        for(int x = 0;x<Duration;x++)
        {
            if (Target == null) break;
            yield return new WaitForSeconds(TickRate);
            Target.health.TakeDamage(PoisonDamage);
        }
        buffEnded.Invoke(this);
    }

    protected override IEnumerator Cleanup()
    {
        yield return null;
    }


}
