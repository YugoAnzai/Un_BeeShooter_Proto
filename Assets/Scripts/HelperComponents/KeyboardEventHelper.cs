using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public enum KeyActionType
{
    KeyDown,
    Key,
    KeyUp
}
[System.Serializable]
public class KeyCodeActionPair
{

    [HorizontalGroup("Key"), LabelWidth(40)]
    public KeyCode key;
    [HorizontalGroup("Key"), LabelWidth(40), LabelText("Type")]
    public KeyActionType actionType;
    public UnityEvent unityEvent;
    
}

public class KeyboardEventHelper : MonoBehaviour
{

    public List<KeyCodeActionPair> keyEvents;

    private void Update()
    {
        foreach(KeyCodeActionPair pair in keyEvents)
        {

            bool call = false;
            if (pair.actionType == KeyActionType.KeyDown)
            {
                if (Input.GetKeyDown(pair.key))
                    call = true;
            } else if (pair.actionType == KeyActionType.Key)
            {
                if (Input.GetKey(pair.key))
                    call = true;
            } else if (pair.actionType == KeyActionType.KeyUp)
            {
                if (Input.GetKeyUp(pair.key))
                    call = true;
            }
            
            if (call)
                pair.unityEvent?.Invoke();
            
        }
    }

}