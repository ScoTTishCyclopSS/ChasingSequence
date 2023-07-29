using System;
using UnityEngine;

[Serializable]
public class Optional<T>
{
    [SerializeField] private bool enabled;
    [SerializeField] private T value;
    public bool Enabled => enabled;
    public T Value => value;
}
