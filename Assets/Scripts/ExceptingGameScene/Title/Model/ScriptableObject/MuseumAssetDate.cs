using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    namespace Model
    {
        [CreateAssetMenu(menuName = "AddressableDate/MuseumAssetDate")]
        public class MuseumAssetDate : ScriptableObject
        {
            public List<Sprite> iconSprits;
            public List<string> iconTitles;
            public List<string> iconinfos;

            public GameObject _book;
        }
    }
}
