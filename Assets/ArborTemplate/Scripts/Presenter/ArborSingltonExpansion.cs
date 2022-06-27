using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArborSingltonExpansion
{
    public static Component GetComponentToArbor(this Component component, string name)
    {
        return ArborComponentSinglton.inctance.NameToComponentChange(name);
    }
    public static T GetComponentToArbor<T>(this Component component, string name) where T : Component
    {
        return ArborComponentSinglton.inctance.NameToComponentChange(name) as T;
    }
}
