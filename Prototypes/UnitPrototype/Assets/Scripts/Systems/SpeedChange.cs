using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpeedChange : Buff
{
    public float SlowStrength = 0;
    public float duration;

    private float originalSpeed;

    public override IEnumerator Effect()
    {
        originalSpeed = Target.BaseMoveSpeed;
        Target.GetComponent<Enemy>().SetAISpeed(originalSpeed + SlowStrength);
        yield return new WaitForSeconds(duration);
        //StartCoroutine(Cleanup());
        buffEnded.Invoke(this);
    }

    protected override IEnumerator Cleanup()
    {
        Target.GetComponent<Enemy>().SetAISpeed(originalSpeed);
        //Debug.Log("Cleaning up");
        yield return null;
    }
}
