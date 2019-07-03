using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public abstract IEnumerator Effect(BuffManager manager);
    public void DestroyBuff()
    {
        Destroy(gameObject);
    }
}
