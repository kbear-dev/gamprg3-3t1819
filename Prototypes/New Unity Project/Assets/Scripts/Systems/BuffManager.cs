using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuffManager : MonoBehaviour
{
    private List<Buff> buffs = new List<Buff>();

    public void Register(Buff buff)
    {
        if(!buffs.Contains(buff)) buffs.Add(buff);
        else
        {
            Remove(buff);
            buffs.Add(buff);
        }
        buff = Instantiate(buff, transform);
        buff.buffEnded.AddListener(Remove);
        ApplyBuff(buff);
    }

    public void Remove(Buff buff)
    {
        buffs.RemoveAll(s => s == buff);
        //Debug.Log("removing buff");
        StartCoroutine(buff.DestroyBuff());
    }

    public void ClearAllBuffs()
    {
        foreach (Buff buff in buffs) buff.DestroyBuff();
        buffs.Clear();
    }

    void ApplyBuff(Buff buff)
    {
        buff.Target = GetComponent<Unit>();
        StartCoroutine(buff.Effect());
    }

    private void OnDestroy()
    {
        ClearAllBuffs();
    }
}
