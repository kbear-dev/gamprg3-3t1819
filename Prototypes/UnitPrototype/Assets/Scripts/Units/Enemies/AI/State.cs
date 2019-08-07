using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyState", menuName = "States/EmptyState")]
public class State : ScriptableObject
{
    // [note] unit references will be dictated by child classes

    // 0 will always be the default/idle state
    public List<State> availableStates;

    public virtual void Act() { }

    // all swap conditions here
    public virtual State CheckStateChanges()
    {
        return SwapState(0);
    }

    protected State SwapState(int stateIndex)
    {
        return availableStates[stateIndex];
    }
}
