using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// from https://unity.com/how-to/architect-game-code-scriptable-objects
[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
