using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    [SerializeField]
    FadeInOut fadeInOut;
    // Start is called before the first frame update
    void Start()
    {
        fadeInOut.FadeIn(3.0f,() => { });
    }
}
