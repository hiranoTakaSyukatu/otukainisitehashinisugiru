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
            private static IUploadTimeReceivable _uploadTimeReceivable;
            private static bool _isNew = false;

            public static void Bind(IUploadTimeReceivable uploadTimeReceivable)
            {
                _uploadTimeReceivable = uploadTimeReceivable;
            }

            public static IUploadTimeReceivable Injection(this IUploadTimeReceivable uploadTimeReceivable)
            {
                return _uploadTimeReceivable;
            }

            public static bool IsNewGetEvent(this IUploadTimeReceivable uploadTimeReceivable)
            {
                return _isNew;
            }

            public static void SetIsNewValue(this IUploadTimeReceivable uploadTimeReceivable, bool value)
            {
                _isNew = value;
            }
        }
    }
}

