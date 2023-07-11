using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>();

    [SerializeField]
    private List<TValue> values = new List<TValue>();

    // serialization
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (var kvp in this)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    // deserialization
    public void OnAfterDeserialize()
    {
        this.Clear();   

        if (keys.Count != values.Count)
        {
            throw new Exception(string.Format("There are {0} keys and {1} values after deserialization. " +
                "Make sure that both key and value types are serializable."));
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }

    public new void Add(TKey key, TValue value)
    {
        if (this.ContainsKey(key))
        {
            Debug.LogWarning($"Key '{key.ToString()}' already exists in dictionary. Value will be overwritten.");
            this[key] = value;
        }
        else
        {
            base.Add(key, value);
        }
    }

    public new bool Remove(TKey key)
    {
        if (!this.ContainsKey(key))
        {
            return false;
        }

        return base.Remove(key);
    }

    public new void Clear()
    {
        base.Clear();
    }

    public new bool ContainsKey(TKey key)
    {
        return base.ContainsKey(key);
    }

    public new bool TryGetValue(TKey key, out TValue value)
    {
        return base.TryGetValue(key, out value);
    }

    public new ICollection<TKey> Keys
    {
        get { return base.Keys; }
    }

    public new ICollection<TValue> Values
    {
        get { return base.Values; }
    }

    public new int Count
    {
        get { return base.Count; }
    }
}
