using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [HideInInspector] public Unit Caster;
    [HideInInspector] public Unit Target;

    public string CardName;
    [TextArea(minLines:1,maxLines:2)]
    public string CardDescription;

    public virtual void OnThrow()
    {
        StartCoroutine(OnEffect());
    }

    protected virtual IEnumerator OnEffect()
    {
        yield break;
    }
}
