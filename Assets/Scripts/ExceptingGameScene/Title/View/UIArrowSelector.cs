using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    namespace View
    {
        public class UIArrowSelector : MonoBehaviour
        {
            [SerializeField]
            GameObject[] imageObjects;
            [SerializeField]
            Sprite[] selectSprites;
            [SerializeField]
            Sprite[] nonSelectSprites;

            int count = 0;
            bool _isActivePopup = false;
            private void Start()
            {
                this.UpdateAsObservable()
                    .Where(x => (int)Input.GetAxisRaw("Vertical") != 0)
                    .Where(x => AllInputCatroller.IsInputable)
                    .Select(x => -(int)Input.GetAxisRaw("Vertical") + count)
                    .Select(x => Mathf.Clamp(x, 0, imageObjects.Length - 1))
                    .ThrottleFirstFrame(12)//‚à‚Æ‚à‚Æ30
                    .Subscribe(x =>
                    {
                        count = x;
                        AllClearActive();
                        imageObjects[count].SetActive(true);
                        imageObjects[count].transform.parent.GetComponent<Image>().sprite = selectSprites[count];
                    })
                    .AddTo(this);

                this.UpdateAsObservable()
                    .Where(x => AllInputCatroller.IsInputable)
                    .Where(x => Input.GetKeyDown(KeyCode.Space))
                    .Subscribe(x =>
                    {
                        imageObjects[count].GetComponent<IArrowSelectorBehavior>()?.EnterAction();
                    });

                AllClearActive();
                imageObjects[count].SetActive(true);
                imageObjects[count].transform.parent.GetComponent<Image>().sprite = selectSprites[count];
            }

            private void AllClearActive()
            {
                for (int i = 0; i < imageObjects.Length; i++)
                {
                    imageObjects[i].SetActive(false);
                    imageObjects[i].transform.parent.GetComponent<Image>().sprite = nonSelectSprites[i];
                }
            }

            public void LoadGameSceneSpriteChange(Sprite selectSp, Sprite nonSelectSp)
            {
                selectSprites[0] = selectSp;
                nonSelectSprites[0] = nonSelectSp;
                AllClearActive();
                imageObjects[count].SetActive(true);
                imageObjects[count].transform.parent.GetComponent<Image>().sprite = selectSprites[count];
            }

            public void IsActivePopupStateChange()
            {
                _isActivePopup = !_isActivePopup;
            }
        }

    }
}
