using Server.SaveSystem;
using Signal.Expansion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UniRx.Triggers;
using UnityEngine.UI;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using UniRx;

public class MuseumDateInsert : MonoBehaviour
{
    private const string TITLE_TEXT = "？？？";
    private const string INFO_TEXT = "？？？？？？？？？？";
    private string jsonStr;
    JsonSaveDate date = new JsonSaveDate();
    PictureBookPage[] pictureBookPage;
    Dictionary<TouchObjectType, PictureBookIconInfo> _toInfo = new Dictionary<TouchObjectType, PictureBookIconInfo>();
    Dictionary<TouchObjectType, Sprite> _toSprite = new Dictionary<TouchObjectType, Sprite>();
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            date = ReadToJson();
            if (date.enumValues.Length == 0)
            {
                MyInit();
                WriteToJson(date);
            }
        }
        catch (FileNotFoundException e)
        {
            // ファイルがなければReader無視
            Debug.LogWarning("ファイルが見つからないため生成します" + e);
            MyInit();
            WriteToJson(date);
        }
        // ページたち
        pictureBookPage = GetComponentsInChildren<PictureBookPage>();
        //var icons = pictureBookPages[0].GetIconInfos();
        foreach (var item1 in pictureBookPage)
        {
            var icons = item1.GetIconInfos();
            foreach (var item2 in icons)
            {
                var isWhite = IsGetTypeEvent(item2.touchObjectType);
                if (!isWhite)
                {
                    item2.iconImage.sprite = item2.brackSprite;
                    item2.infoText.text = INFO_TEXT;
                    item2.titleText.text = TITLE_TEXT;
                }
            }
            if (item1 != pictureBookPage[0])
            {
                item1.gameObject.SetActive(false);
            }
        }
        AllInputCatroller.IsInputable = false;


        this.UpdateAsObservable()
             .Where(x => (int)Input.GetAxisRaw("Horizontal") != 0)
                    .Select(x => (int)Input.GetAxisRaw("Horizontal") + count)
                    .Select(x => Mathf.Clamp(x, 0, pictureBookPage.Length - 1))
                    .ThrottleFirstFrame(30)
                    .Subscribe(x =>
                    {
                        count = x;
                        Debug.Log(count);
                        foreach (var item in pictureBookPage)
                        {
                            item.gameObject.SetActive(false);
                        }
                        pictureBookPage[count].gameObject.SetActive(true);
                        
                    })
                    .AddTo(this);

        this.UpdateAsObservable()
            .Where(x => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(x =>
            {
                AllInputCatroller.IsInputable = true;  
                Destroy(gameObject);
            }).AddTo(this);
    }

    private bool IsGetTypeEvent(TouchObjectType touchObjectType)
    {
        // 意味のない数字
        int tmpNum = 9999;
        for (int i = 0; i < date.enumValues.Length; i++)
        {
            if ((int)touchObjectType == date.enumValues[i])
            {
                tmpNum = i;
            }
        }
        return date.isNewUpdates[tmpNum];
    }

    private JsonSaveDate ReadToJson()
    {
        JsonSaveDate resultdate;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/savedata.json"))
        {
            jsonStr = reader.ReadToEnd();
            resultdate = JsonUtility.FromJson<JsonSaveDate>(jsonStr);
        }
        Debug.Log(resultdate.enumValues.Length);
        return resultdate;
    }

    private void WriteToJson(JsonSaveDate date)
    {
        using (StreamWriter writer = new StreamWriter(Application.dataPath + "/savedata.json", false))
        {
            jsonStr = JsonUtility.ToJson(date);
            writer.Write(jsonStr);
            writer.Flush();
        }
    }

    private void MyInit()
    {

        var enumValues = Enum.GetValues(typeof(TouchObjectType));
        date.enumValues = new int[enumValues.Length];
        date.isNewUpdates = new bool[enumValues.Length];
        date.clearStageNum = 0;
        for (int i = 0; i < enumValues.Length; i++)
        {
            date.enumValues[i] = (int)enumValues.GetValue(i);
            date.isNewUpdates[i] = false;
        }
    }
}
