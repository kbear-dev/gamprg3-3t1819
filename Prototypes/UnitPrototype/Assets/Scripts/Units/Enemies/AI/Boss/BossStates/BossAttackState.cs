using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "States/Boss/AttackState")]
public class BossAttackState : BossState
{
    public float RetreatAtHealth;
    public float FireInterval;

    public override void Act()
    {
        boss.SetAISpeed(boss.moveSpeed);
    }

    public override State CheckStateChanges()
    {
        if (boss.GetCurrentHealthPercent() > RetreatAtHealth)
        {
            if (!boss.isPlayerInRange)
            {
                return SwapState(0);
            }

            if (!boss.hasBulletHellStarted) boss.StartBulletHell(FireInterval);
            return this;
        }
        else
        {
            return SwapState(1);
        }
    }
}
