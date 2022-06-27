using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

public class PictureBookIcon : MonoBehaviour
{
    [SerializeField]
    private TouchObjectType _touchObjectType;
    [SerializeField]
    Sprite brackSprite;

    public PictureBookIconInfo GetInfo()
    {
        return new PictureBookIconInfo(
            GetComponent<Image>(),
            GetComponentInChildren<PictureBookTitleText>().GetTitleText(),
            GetComponentInChildren<PictureBookInfoText>().GetInfoText(),
            _touchObjectType,
            brackSprite
            );
    }
}
