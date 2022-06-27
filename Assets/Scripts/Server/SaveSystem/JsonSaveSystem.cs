using Connector.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using System.IO;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using System;
using Title.Model;
using Common.Model;
using Signal;

namespace Server
{
    namespace SaveSystem
    {
        public class JsonSaveSystem : IInitializable, IJsonClearDateGettable
        {
            [Inject]
            private IServerInfoUploadable _serverInfoUploadable;
            private static JsonSaveDate date = new JsonSaveDate();
            private string jsonStr;
            public void Initialize()
            {
                MyInit();
                _serverInfoUploadable.GetClearStageObservable()
                    .Subscribe(x =>
                    {
                        try
                        {
                            date = ReadToJson();
                        }
                        catch (FileNotFoundException e)
                        {
                            // ファイルがなければReader無視
                            Debug.LogWarning("ファイルが見つからないため生成します" + e);
                        }
                        finally
                        {
                            ClearDateValueChange(x);
                            WriteToJson(date);
                        }
                    });

                _serverInfoUploadable.GetInfoUpdateObservable()
                    .Subscribe(x =>
                    {
                        try
                        {
                            date = ReadToJson();
                        }
                        catch (FileNotFoundException e)
                        {
                            // ファイルがなければReader無視
                            Debug.LogWarning("ファイルが見つからないため生成します" + e);
                        }
                        finally
                        {
                            DateValueChange(x);
                            WriteToJson(date);
                        }
                    });
            }

            private JsonSaveDate ReadToJson()
            {
                JsonSaveDate resultdate;
                using (StreamReader reader = new StreamReader(Application.dataPath + "/savedata.json"))
                {
                    jsonStr = reader.ReadToEnd();
                    resultdate = JsonUtility.FromJson<JsonSaveDate>(jsonStr);  
                }
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

            private void DateValueChange(int enumValue)
            {
                for (int i = 0; i < date.enumValues.Length; i++)
                {
                    if (date.enumValues[i] != enumValue) continue;
                    if (enumValue / 1000000 != 1)
                    {
                        CommonEventCheck(enumValue);
                    }
                    else
                    {
                        _serverInfoUploadable.GetUpdateResult(new ServerResultInfo(!date.isNewUpdates[i]));
                    }
                    date.isNewUpdates[i] = true;
                }
            }

            private void CommonEventCheck(int enumValue)
            {
                var value = enumValue / 1000000;
                for (int j = 0; j < date.enumValues.Length; j++)
                {
                    if (date.enumValues[j] / 1000000 != value) continue;
                    if (date.isNewUpdates[j])
                    {
                        _serverInfoUploadable.GetUpdateResult(new ServerResultInfo(false));
                    }
                    else
                    {
                        date.isNewUpdates[j] = true;
                    }
                }
            }

            private void ClearDateValueChange(int stageNum)
            {
                date.clearStageNum = stageNum;
            }

            int IJsonClearDateGettable.GetClearStageNum()
            {
                try
                {
                    date = ReadToJson();
                }
                catch (FileNotFoundException e)
                {
                    Debug.LogWarning(e);
                    WriteToJson(date);
                }
                return date.clearStageNum;
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
    }
}
