using System.Collections.Generic;
using UnityEngine;
using YugoA.Helpers;

namespace YugoA.Save.PlayerPrefsScriptable
{

    public enum ValueType {
        INT,
        FLOAT,
        BOOL,
        STRING
    }

    public class PlayerPrefsManager {

        private string saveKeysPath;

        public static bool HasKey(SaveKey key) {
            return PlayerPrefs.HasKey(key.name);
        }

        public static void DeleteKey(SaveKey key) {
            PlayerPrefs.DeleteKey(key.name);
        }

        #region INT
        public static int GetInt(SaveKey key) {
            if (key.valueType != ValueType.INT) {
                throw new PlayerPrefsException(key.name + " Does not store INT value.");
            }
            return PlayerPrefs.GetInt(key.name);
        }

        public static void SetInt(SaveKey key, int value) {
            if (key.valueType != ValueType.INT) {
                throw new PlayerPrefsException(key.name + " Does not store INT value.");
            }
            PlayerPrefs.SetInt(key.name, value);
        }

        public static bool IsInt(SaveKey key) {
            return key.valueType == ValueType.INT;
        }
        #endregion

        #region BOOL
        public static bool GetBool(SaveKey key) {
            if (key.valueType != ValueType.BOOL) {
                throw new PlayerPrefsException(key.name + " Does not store Bool value.");
            }
            return PlayerPrefs.GetInt(key.name) == 1 ? true : false;
        }

        public static void SetBool(SaveKey key, bool value) {
            if (key.valueType != ValueType.BOOL) {
                throw new PlayerPrefsException(key.name + " Does not store Bool value.");
            }
            int integer = value ? 1 : 0;
            PlayerPrefs.SetInt(key.name, integer);
        }

        public static bool IsBool(SaveKey key) {
            return key.valueType == ValueType.BOOL;
        }
        #endregion

        #region FLOAT
        public static float GetFloat(SaveKey key) {
            if (key.valueType != ValueType.FLOAT) {
                throw new PlayerPrefsException(key.name + " Does not store FLOAT value.");
            }
            return PlayerPrefs.GetFloat(key.name);
        }

        public static void SetFloat(SaveKey key, float value) {
            if (key.valueType != ValueType.FLOAT) {
                throw new PlayerPrefsException(key.name + " Does not store FLOAT value.");
            }
            PlayerPrefs.SetFloat(key.name, value);
        }

        public static bool IsFloat(SaveKey key) {
            return key.valueType == ValueType.FLOAT;
        }
        #endregion

        #region STRING
        public static string GetString(SaveKey key) {
            if (key.valueType != ValueType.STRING) {
                throw new PlayerPrefsException(key.name + " Does not store STRING value.");
            }
            return PlayerPrefs.GetString(key.name);
        }

        public static void SetString(SaveKey key, string value) {
            if (key.valueType != ValueType.STRING) {
                throw new PlayerPrefsException(key.name + " Does not store STRING value.");
            }
            PlayerPrefs.SetString(key.name, value);
        }

        public static bool IsString(SaveKey key) {
            return key.valueType == ValueType.STRING;
        }
        #endregion

        #region RESET
        public static void DeleteAllKeys(SaveKey[] keys) {
            foreach(SaveKey key in keys) {
                DeleteKey(key);
            }
        }
        #endregion

        #region DEBUG
        public static void LogAllKeyValues(SaveKey[] keys) {

            if (!Debug.isDebugBuild) { return; }

            string fullLog = "";

            foreach(SaveKey key in keys) {
                string line = key.name + ": ";

                switch (key.valueType)
                {

                    case ValueType.INT:
                        line += LogHelper.WrapColor(GetInt(key).ToString(), "blue");
                        break;
                    case  ValueType.FLOAT:
                        line += LogHelper.WrapColor(GetFloat(key).ToString(), "cyan");
                        break;
                    case  ValueType.BOOL:
                        string color = GetBool(key) ? "green" : "black";
                        line += LogHelper.WrapColor(GetBool(key).ToString(), color);
                        break;
                    case  ValueType.STRING:
                        line += LogHelper.WrapColor(GetString(key), "maroon");
                        break;
                    default:
                        break;

                }
                fullLog += line + '\n';

            }

            LogHelper.Log(fullLog);

        }
        #endregion
    }

    [System.Serializable]
    public class PlayerPrefTypeException : System.Exception
    {
        public PlayerPrefTypeException() { }
        public PlayerPrefTypeException(string message) : base(message) { }
        public PlayerPrefTypeException(string message, System.Exception inner) : base(message, inner) { }
        protected PlayerPrefTypeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}