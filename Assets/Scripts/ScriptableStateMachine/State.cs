using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace YugoA.ScriptableSM
{

    [CreateAssetMenu(fileName = "State", menuName = "ScriptableSM/State")]
    public class State : ScriptableObject {
        
        public List<Action> actions;
        public List<Transition> transitions;
        public Color sceneGizmoColor = Color.grey;

        public void UpdateState(StateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateController controller)
        {
            actions.ForEach(a => a.Act(controller));
        }

        private void CheckTransitions(StateController controller)
        {

            foreach(Transition transition in transitions)
            {
                bool decisionSucceeded = transition.decision.Decide(controller);

                if (decisionSucceeded)
                    controller.TransitionToState(transition.trueState);
                else
                    controller.TransitionToState(transition.falseState);
                
            }
        }

    }
}