using UnityEngine;

namespace YugoA.ScriptableSM
{

    public abstract class Decision : ScriptableObject
    {

        public abstract bool Decide(StateController controller);

    }
    
}