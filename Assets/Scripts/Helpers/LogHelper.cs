using UnityEngine;

namespace YugoA.Helpers
{

    public static class LogHelper
    {

        public static void Log(string message, GameObject obj = null)
        {

            if (!UnityEngine.Debug.isDebugBuild)
                return;

            UnityEngine.Debug.Log(message, obj);

        }

        public static string WrapColor(string toWrap, string color)
        {
            return $"<color={color}>{toWrap}</color>";
        }

        public static string WrapColor(string toWrap, Color color)
        {
            return string.Format(
                "<color=#{0:X2}{1:X2}{2:X2}>{3}</color>", 
                (byte)(color.r * 255f), 
                (byte)(color.g * 255f), 
                (byte)(color.b * 255f), 
                toWrap);
        }

        public static void Log(string message, string color)
        {
            Log(WrapColor(message, color));
        }

        public static void Log(string message, Color color)
        {
            Log(WrapColor(message, color));
        }

    }

}