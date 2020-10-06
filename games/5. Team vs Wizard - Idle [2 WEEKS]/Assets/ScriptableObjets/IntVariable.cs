using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// from https://unity.com/how-to/architect-game-code-scriptable-objects
[CreateAssetMenu]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int InitialValue;

    [NonSerialized]
    public int RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
