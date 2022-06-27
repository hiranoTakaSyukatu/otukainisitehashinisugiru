using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class DebugNextScene : MonoBehaviour
{
    public void NextSelectScene()
    {
        LoadScene("GameSelectScene");
    }

    public void NextGameScene()
    {
        LoadScene("GameScene");
    }
}
