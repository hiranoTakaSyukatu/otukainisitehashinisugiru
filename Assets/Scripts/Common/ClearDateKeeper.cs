using Server.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using Title.Model;
using UnityEngine;
using Zenject;

namespace Common
{
    namespace Model
    {
        public class ClearDateKeeper
        {
            IJsonClearDateGettable _jsonClearDateGettable = new JsonSaveSystem();

            public int GetClearStageNum()
            {
                return _jsonClearDateGettable.GetClearStageNum();
            }
        }
    }
}
