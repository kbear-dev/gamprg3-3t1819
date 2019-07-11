using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBuff : Card
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(OnEffect(Target));
    }

    protected override IEnumerator OnEffect(Collision2D collision)
    {
        return base.OnEffect(collision);
    }
}
