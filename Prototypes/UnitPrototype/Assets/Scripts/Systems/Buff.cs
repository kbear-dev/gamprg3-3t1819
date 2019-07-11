using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnBuffEnded :UnityEvent<Buff> { }
public abstract class Buff : MonoBehaviour
{
    [HideInInspector] public OnBuffEnded buffEnded = new OnBuffEnded();
    public Unit Target;

    public abstract IEnumerator Effect();
    protected abstract IEnumerator Cleanup();
    public IEnumerator DestroyBuff()
    {
        yield return StartCoroutine(Cleanup());
        yield return null;
        Destroy(gameObject);
    }
}
