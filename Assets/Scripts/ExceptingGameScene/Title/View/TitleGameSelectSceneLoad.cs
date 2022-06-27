using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class TitleGameSelectSceneLoad : MonoBehaviour, IArrowSelectorBehavior
{
    [SerializeField]
    FadeInOut fadeInOut;
    void IArrowSelectorBehavior.EnterAction()
    {
        fadeInOut.FadeOut(1.0f, () => LoadScene("GameSelectScene"));
    }
}
