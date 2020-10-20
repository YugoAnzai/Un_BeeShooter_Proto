using UnityEngine;

namespace YugoA.ScriptableSM
{

    [CreateAssetMenu(fileName = "ScaleSize", menuName = "ScriptableSM/Decisions/ScaleSize")]
    public class ScaleSizeDecision : Decision {
        
        public bool bigger;
        public float biggerComparison;
        public bool smaller;
        public float smallerComparision;

        public override bool Decide(StateController controller)
        {
            
            if (bigger && controller.transform.localScale.magnitude > biggerComparison)
            {
                return true;
            }

            if (smaller && controller.transform.localScale.magnitude < smallerComparision)
            {
                return true;
            }

            return false;

        }

    }

}