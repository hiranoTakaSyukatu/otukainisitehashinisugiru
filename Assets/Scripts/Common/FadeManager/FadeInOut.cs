using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    Image image;
    Color color;

    private float count = 0;

    public void FadeIn(float time, Action callBack)
    {
        color = image.color;
        image.color = new Color(color.r, color.g, color.b, 1.0f);
        StartCoroutine(LateFadeIn(time, callBack));
    }

    private IEnumerator LateFadeIn(float time, Action callBack)
    {
        count = 0;
        while (count < time)
        {
            yield return null;
            image.color = new Color(color.r, color.g, color.b, (1 - count) / time);
            count += Time.deltaTime;
        }
        callBack();
    }

    public void FadeOut(float time, Action callBack)
    {
        color = image.color;
        image.color = new Color(color.r, color.g, color.b, 0.0f);
        StartCoroutine(LateFadeOut(time, callBack));
    }

    private IEnumerator LateFadeOut(float time, Action callBack)
    {
        count = 0;
        while (count < time)
        {
            yield return null;
            image.color = new Color(color.r, color.g, color.b, count / time);
            count += Time.deltaTime;
        }
        callBack();
    }
}
