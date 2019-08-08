using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuffManager : MonoBehaviour
{
    private List<Buff> buffs = new List<Buff>();

    public IEnumerator Register(Buff buff)
    {
        Buff toAdd = Instantiate(buff, transform);
        if (buffs.Find(s => s.GetType() == buff.GetType()))
        {
            Buff toRemove = buffs.Find(s => s.GetType() == buff.GetType());
            toRemove.buffEnded.RemoveAllListeners();
            Remove(toRemove);
            yield return null;
        }

        buffs.Add(toAdd);        

        toAdd.buffEnded.AddListener(Remove);
        ApplyBuff(toAdd);
    }

    public void Remove(Buff buff)
    {
        buffs.RemoveAll(s => s.GetType() == buff.GetType());
        buffs.TrimExcess();
        //buff.buffEnded.RemoveAllListeners();
        StartCoroutine(buff.DestroyBuff());
    }

    public void ClearAllBuffs()
    {
        foreach (Buff buff in buffs) buff.DestroyBuff();
        buffs.Clear();
    }

    void ApplyBuff(Buff buff)
    {
        StartCoroutine(buff.Effect());
    }

    private void OnDestroy()
    {
        ClearAllBuffs();
    }
}
