using Connector.Player;
using Connector.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Signal
{
    namespace Expansion
    {
        public static partial class InterfaceExpansion
        {
            private static IObjectRecevetable _objectRecevetable;

            public static void Bind(IObjectRecevetable objectRecevetable)
            {
                _objectRecevetable = objectRecevetable;
            }

            public static IObjectRecevetable Injection(this IObjectRecevetable objectRecevetable)
            {
                return _objectRecevetable;
            }
        }
    }
}

