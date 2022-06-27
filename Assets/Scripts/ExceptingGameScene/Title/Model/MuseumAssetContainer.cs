using System.Collections;
using System.Collections.Generic;
using Title.Model;
using UnityEngine;

public class MuseumAssetContainer : IMuseumAssetSettable
{
    private static MuseumAssetDate assetDate;
    public static MuseumAssetDate GetMuseumAssetDate() => assetDate;

    bool IMuseumAssetSettable.IsVaild()
    {
        return assetDate != null;
    }

    void IMuseumAssetSettable.SetDatebase(MuseumAssetDate museumAssetDate)
    {
        assetDate = museumAssetDate;
    }
}
