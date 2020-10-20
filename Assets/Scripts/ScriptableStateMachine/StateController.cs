using UnityEngine;

namespace YugoA.ScriptableSM
{

    public class StateController : MonoBehaviour {

        public State currentState;
        public State remainState;
        public bool activateAiOnStart = true;

        [HideInInspector] public float stateTimeElapsed;

        protected virtual Vector3 gizmoPosition => transform.position;
        protected virtual float gizmoRadius => 2;

        private bool aiActive;

        protected virtual void Start()
        {
            if (activateAiOnStart)
                aiActive = true;
        }

        protected virtual void Update()
        {
            StateUpdate();
        }

        private void StateUpdate()
        {
            if (!aiActive)
                return;

            currentState.UpdateState(this);
        }

        private void OnDrawGizmos()
        {
            if(currentState != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(gizmoPosition, gizmoRadius);
            }
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

    }

}