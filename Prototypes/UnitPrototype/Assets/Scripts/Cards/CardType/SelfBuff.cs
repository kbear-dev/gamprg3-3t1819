using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBuff : Card
{
    public Buff Buff;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(OnEffect(Target));
    }

    protected override IEnumerator OnEffect()
    {
        Caster.GetComponent<BuffManager>().Register(Buff);
        yield return null;
    }
}
