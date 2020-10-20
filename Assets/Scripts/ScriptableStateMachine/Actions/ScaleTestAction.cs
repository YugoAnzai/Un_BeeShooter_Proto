using UnityEngine;

namespace YugoA.ScriptableSM
{

    [CreateAssetMenu(fileName = "ScaleTest", menuName = "ScriptableSM/Actions/ScaleTest")]
    public class ScaleTestAction : Action
    {

        public float speed;

        public override void Act(StateController controller)
        {
            Vector3 newScale = controller.transform.localScale + Vector3.one * speed;
            controller.transform.localScale = newScale;
        }

    }

}