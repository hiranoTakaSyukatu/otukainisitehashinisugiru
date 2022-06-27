using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBookPage : MonoBehaviour
{
    PictureBookIconInfo[] pictureBookIconInfos;
    public PictureBookIconInfo[] GetIconInfos()
    {
        var tmp = GetComponentsInChildren<PictureBookIcon>();
        pictureBookIconInfos = new PictureBookIconInfo[tmp.Length];
        for (int i = 0; i < pictureBookIconInfos.Length; i++)
        {
            pictureBookIconInfos[i] = tmp[i].GetInfo();
        }
        return pictureBookIconInfos;
    }
}
