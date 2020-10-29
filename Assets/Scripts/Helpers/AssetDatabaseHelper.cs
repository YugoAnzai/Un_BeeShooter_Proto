using UnityEditor;
using UnityEngine;

namespace YugoA.Helpers
{

    #if UNITY_EDITOR

    public static class AssetDatabaseHelper
    {

        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            
            string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);
            T[] a = new T[guids.Length];
            for(int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;

        }

    }

    #endif
    
}