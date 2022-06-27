using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    namespace View
    {
        public class OpenSettingPopUp : MonoBehaviour, IArrowSelectorBehavior
        {
            void IArrowSelectorBehavior.EnterAction()
            {
                Instantiate(MuseumAssetContainer.GetMuseumAssetDate()._book);
            }
        }
    }
}

