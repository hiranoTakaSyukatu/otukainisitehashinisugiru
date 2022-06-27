using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArborObjectContainer
{
    private static Dictionary<string, GameObject> _container = new Dictionary<string, GameObject>();
    
    public static void Clear()
    {
        _container.Clear();
    }

    public static void Bind(string key,GameObject value)
    {
        _container[key] = value;
    }

    public static GameObject GetObject(string key)
    {
        if (_container.ContainsKey(key))
        {
            return _container[key];
        }
        return null;
    }
}
