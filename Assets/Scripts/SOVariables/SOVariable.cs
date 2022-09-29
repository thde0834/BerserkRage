using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pretty much a global variable yuh
public abstract class SOVariable<T> : ScriptableObject where T : new()
{
    [SerializeField]
    private T _value = new T();
    
    public T Value
    {
        get => _value;
        protected set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    public event Action<T> OnValueChanged;

    public abstract void SetValue(T value);
    public abstract void SetValue(SOVariable<T> value);

    public abstract void ApplyChange(T amount);
    public abstract void ApplyChange(SOVariable<T> amount);
}
