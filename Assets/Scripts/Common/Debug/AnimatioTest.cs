using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatioTest : MonoBehaviour
{
    SimpleAnimation simpleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        simpleAnimation = GetComponent<SimpleAnimation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            simpleAnimation.CrossFade("Car", 0.0f);
        }
    }
}
