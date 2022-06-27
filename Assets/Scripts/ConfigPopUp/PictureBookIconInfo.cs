using UnityEngine.UI;
using UnityEngine;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

public struct PictureBookIconInfo
{
    public PictureBookIconInfo(Image image, Text text1, Text text2, TouchObjectType touchObjectType, Sprite brackSprite)
    {
        iconImage = image;
        titleText = text1;
        infoText = text2;
        this.touchObjectType = touchObjectType;
        this.brackSprite = brackSprite;
    }
    public readonly TouchObjectType touchObjectType;
    public readonly Image iconImage;
    public readonly Text titleText;
    public readonly Text infoText;
    public readonly Sprite brackSprite;
}