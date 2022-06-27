using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInputer : MonoBehaviour
{
    [SerializeField]
    FadeInOut fadeInOut;
    // Start is called before the first frame update
    void Start()
    {
        fadeInOut.FadeOut(1f,() =>Debug.Log("aa"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
