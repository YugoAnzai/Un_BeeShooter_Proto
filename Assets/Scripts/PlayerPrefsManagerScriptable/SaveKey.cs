using UnityEngine;
using YugoA.Save.PlayerPrefsScriptable;

namespace YugoA.Save.PlayerPrefsScriptable
{

    [CreateAssetMenu(fileName = "SaveKey", menuName = "YugoA/Save/SaveKey", order = 0)]
    public class SaveKey : ScriptableObject
    {

        public ValueType valueType;

        #if UNITY_EDITOR
        [Multiline]
        public string developerDescription;
        #endif

    }

}