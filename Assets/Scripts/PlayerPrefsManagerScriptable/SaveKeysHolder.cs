using UnityEngine;
using Sirenix.OdinInspector;
using YugoA.Save.PlayerPrefsScriptable;
using YugoA.Helpers;

namespace YugoA.Save.PlayerPrefsScriptable
{

    [CreateAssetMenu(fileName = "_SaveKeysHolder", menuName = "YugoA/Save/SaveKeysHolder", order = 0)]
    public class SaveKeysHolder : ScriptableObject
    {
        [SerializeField, ReadOnly]
        private SaveKey[] keys;
        public SaveKey[] Keys => keys;

        private void OnEnable()
        {
            #if UNITY_EDITOR
            keys = AssetDatabaseHelper.GetAllInstances<SaveKey>();
            #endif
        }

    }

}