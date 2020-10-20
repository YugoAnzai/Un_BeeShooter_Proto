using UnityEngine;

namespace YugoA.ScriptableSM
{

    [CreateAssetMenu(fileName = "RotationTest", menuName = "ScriptableSM/Actions/RotationTest")]
    public class RotationTestAction : Action
    {

        public Vector3 rotationSpeed;

        public override void Act(StateController controller)
        {
            Rotate(controller);
        }

        private void Rotate(StateController controller)
        {
            
            Vector3 rotate = rotationSpeed * Time.deltaTime;
            controller.transform.Rotate(
                rotate.x,
                rotate.y,
                rotate.z
            );

        }

    }

}