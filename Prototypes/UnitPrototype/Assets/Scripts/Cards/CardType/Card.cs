using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [HideInInspector] public Unit Caster;
    [HideInInspector] public Unit Target;


    protected virtual IEnumerator OnEffect()
    {
        yield break;
    }
}
