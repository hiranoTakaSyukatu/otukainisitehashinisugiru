using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

namespace Signal
{
    public class C_TouchObjectType : MonoBehaviour
    {
        public enum TouchObjectType
        {
            // Stage_1　死ぬイベント
            YANKEY          = 1_01_01_01,
            CROSSWALK       = 4_01_01_02,
            CROSSWALK_2     = 4_01_01_03,
            CROSSWALK_3     = 4_01_01_04,
            PARKING         = 1_01_01_05,
            PUDDLE          = 1_01_01_06,
            SIGNALFALL      = 1_01_01_07,
            PARKKID     　　= 1_01_01_08,
            CHILDHOODFRIEND = 1_01_01_09,
            F12_1 = 2_01_01_10,
            PLAYERDASH_1 = 3_01_01_11,

            // Stage_2 
            MARLIN          = 1_02_01_01,
            LIFT            = 1_02_01_02,
            FISHSTORE       = 1_02_01_03,
            GEENGROCER      = 1_02_01_04,
            BUTCHER         = 1_02_01_05,
            CAT             = 1_02_01_06,     
            BIGMADAM        = 1_02_01_07,
            F12_2           = 2_02_01_08,
            PLAYERDASH_2    = 3_02_01_09,


            // Stage_1 会話イベント
            CONVERSATON_YANKEY          = 1_01_02_01,
            CONVERSATON_CHILDHOODFRIEND = 1_01_02_02,
            CONVERSATON_PARKKID = 1_01_02_03,

            // Stage_2
            CONVERSATION_FISHSTORE  = 1_02_02_01,
            CONVERSATION_GEENGROCER = 1_02_02_02,
            CONVERSATION_BUTCHER    = 1_02_02_03,
            CONVERSATION_BIGMADAM   = 1_02_02_04,


            // Stage1 その他
            STAGECHANGER_1            = 1_01_03_01,

            // Stage2
            CLEARSCENECHANGER         = 1_02_03_01,
            STAGECHANGER_2            = 2_02_03_02,
        }

        public static TouchObjectType[] IntToEum(int[] vs)
        {
            TouchObjectType[] touchObjectTypes = new TouchObjectType[vs.Length];

            for (int i = 0; i < touchObjectTypes.Length; i++)
            {
                touchObjectTypes[i] = (TouchObjectType)vs[i];
            }
            return touchObjectTypes;
        }
    }
}

