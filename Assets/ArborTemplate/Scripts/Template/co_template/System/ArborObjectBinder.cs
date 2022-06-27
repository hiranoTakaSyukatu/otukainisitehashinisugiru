using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArborObjectBinder : MonoBehaviour
{
    [SerializeField]
    private string _key;
    void Start()
    {
        ArborObjectContainer.Bind(_key, this.gameObject);
    }
}
