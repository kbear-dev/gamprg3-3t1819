using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenseState", menuName = "States/Boss/DefenseState")]
public class BossDefenseState : BossState
{
    public float ReturnAtHealth;
    public float HealInterval;
    public int HealValue;

    public override void Act()
    {
        boss.SetAISpeed(boss.moveSpeed/2);
    }

    public override State CheckStateChanges()
    {
        if (boss.hasBulletHellStarted) boss.StopBulletHell();
        if (boss.isHealing) boss.StopHealing();

        if (boss.GetCurrentHealthPercent() >= ReturnAtHealth)
        {
            if (boss.isPlayerInRange)
            {
                return SwapState(1);
            }
            else
            {
                return SwapState(0);
            }
        }
        else
        {
            if (!boss.isHealing) boss.StartHealing(HealValue, HealInterval);
            return this;
        }
    }
}
