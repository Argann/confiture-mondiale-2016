using UnityEngine;
using System.Collections.Generic;

namespace NewScripts
{
    public static class InputBroker
    {
        private static List<KeyCode> _forcedKeyDowns = new List<KeyCode>();

        public static bool GetKeyDown(KeyCode aKey)
        {
            return Input.GetKeyDown(aKey) || _forcedKeyDowns.Contains(aKey);
        }

        public static void SetKeyDown(KeyCode aKey)
        {
            _forcedKeyDowns.Add(aKey);
        }

        public static void UnsetKeyDown(KeyCode aKey)
        {
            _forcedKeyDowns.Remove(aKey);
        }
    }
}