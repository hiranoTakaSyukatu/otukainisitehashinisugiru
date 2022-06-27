using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContainerController : MonoBehaviour
{
    public static AnimationContainerController I { get; set; }
    private SimpleAnimation _simpleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _simpleAnimation = GetComponent<SimpleAnimation>();
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(I);
        }
    }

    public void AnimationPlay(string key)
    {
        _simpleAnimation.CrossFade(key, 0.0f);
    }
}
