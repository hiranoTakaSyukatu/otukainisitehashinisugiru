using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArborComponentSinglton : MonoBehaviour
{
    public static ArborComponentSinglton inctance;

    public string[] componentsNames;
    public Component[] components;
    // Start is called before the first frame update
    void Start()
    {
        if (inctance == null)
        {
            inctance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Component NameToComponentChange(string name)
    {
        for (int i = 0; i < componentsNames.Length; i++)
        {
            if (componentsNames[i] == name) return components[i];
        }
        return null;
    }
}
