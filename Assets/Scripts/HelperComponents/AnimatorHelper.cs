using System;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour {
    
    public Action action;

    public void CallAction() {
        action?.Invoke();
        action = null;
    }

}