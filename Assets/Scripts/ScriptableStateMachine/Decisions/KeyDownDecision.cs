using UnityEngine;

namespace YugoA.ScriptableSM
{

    [CreateAssetMenu(fileName = "KeyDown", menuName = "ScriptableSM/Decisions/KeyDown")]
    public class KeyDownDecision : Decision
    {

        public KeyCode key;

        public override bool Decide(StateController controller)
        {
            return Input.GetKeyDown(key);
        }

    }

}