using UnityEngine;
using Sirenix.OdinInspector;
using YugoA.Save.PlayerPrefsScriptable;

namespace YugoA.Save.PlayerPrefsScriptable
{
    
    public class PlayerPrefsSaver : MonoBehaviour {

        public SaveKeysHolder saveKeysHolder;

        public SaveKey saveKey;

        [ShowIf("KeyIsIntValue")]
        public int intValue;
        [ShowIf("KeyIsFloatValue")]
        public float floatValue;
        [ShowIf("KeyIsBoolValue")]
        public bool boolValue;
        [ShowIf("KeyIsStringValue")]
        public string stringValue;

        [Button]
        public void Save()
        {
            if (PlayerPrefsManager.IsInt(saveKey)) {
                PlayerPrefsManager.SetInt(saveKey, intValue);
            } else if (PlayerPrefsManager.IsFloat(saveKey)) {
                PlayerPrefsManager.SetFloat(saveKey, floatValue);
            } else if (PlayerPrefsManager.IsBool(saveKey)) {
                PlayerPrefsManager.SetBool(saveKey, boolValue);
            } else { // string
                PlayerPrefsManager.SetString(saveKey, stringValue);
            }
        }

        [Button]
        public void LogAllKeys()
        {
            PlayerPrefsManager.LogAllKeyValues(saveKeysHolder.Keys);
        }

        [Button]
        public void ResetSave()
        {
            PlayerPrefsManager.DeleteAllKeys(saveKeysHolder.Keys);
        }

        private bool KeyIsIntValue() {
            if (saveKey == null) return false;
            return PlayerPrefsManager.IsInt(saveKey);
        }
        private bool KeyIsFloatValue() {
            if (saveKey == null) return false;
            return PlayerPrefsManager.IsFloat(saveKey);
        }
        private bool KeyIsBoolValue() {
            if (saveKey == null) return false;
            return PlayerPrefsManager.IsBool(saveKey);
        }
        private bool KeyIsStringValue() {
            if (saveKey == null) return false;
            return PlayerPrefsManager.IsString(saveKey);
        }

    }

}