using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnBuffEnded :UnityEvent<Buff> { }
public abstract class Buff : MonoBehaviour
{
    [HideInInspector] public OnBuffEnded buffEnded = new OnBuffEnded();

    public abstract IEnumerator Effect(Unit target);
    public void DestroyBuff()
    {
        Destroy(gameObject);
    }
}
