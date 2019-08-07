using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : State
{
    public Boss boss { get; set; }

    public override void Act() { }

    public override State CheckStateChanges()
    {
        return availableStates[0];
    }
}
