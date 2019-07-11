using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpeedChange : Buff
{
    public float SlowStrength = 0;
    public float duration;

    public override IEnumerator Effect(Unit target)
    {
        AIPath path = target.GetComponent<AIPath>();
        if (path != null)
        {
            path.maxSpeed -= SlowStrength;
            yield return new WaitForSeconds(duration);
            path.maxSpeed += SlowStrength;
        }
        buffEnded.Invoke(this);
    }
}
