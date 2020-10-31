using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{
    
    [SerializeField] private int targetFramerate = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFramerate;
        YugoA.Helpers.LogHelper.Log($"Framerate Set: {targetFramerate}", Color.yellow);
    }

}
