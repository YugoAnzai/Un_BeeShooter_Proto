using UnityEngine;
namespace YugoA.ScriptableSM
{

    [System.Serializable]
    public class Transition
    {

        public Decision decision;
        public State trueState;
        public State falseState;

    }
    
}