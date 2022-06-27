using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    namespace View
    {
        public class LoadGameSceneTextChanger : MonoBehaviour
        {
            [SerializeField]
            private UIArrowSelector UIArrowSelector;
            [SerializeField]
            private Sprite _selectSprite;
            [SerializeField]
            private Sprite _nonSelectSprite;

            public event Func<bool> IsFirastCheckFunc;
            // Start is called before the first frame update
            void Update()
            {
                if (IsFirastCheckFunc())
                {
                    UIArrowSelector.LoadGameSceneSpriteChange(_selectSprite, _nonSelectSprite);
                    Destroy(this);
                }
            }
        }
    }
}


