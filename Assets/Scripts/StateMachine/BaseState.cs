using UnityEngine;

namespace Astrocat
{
    namespace StateMachine
    {
        public abstract class BaseState
        {
            public virtual void EnterState()
            {
                return;
            }

            public virtual void StateUpdate()
            {
                return;
            }

            public virtual void StateOnTriggerEnter2D(Collider2D collider) {
                return;
            }

            public virtual void StateOnTriggerExit2D(Collider2D collider)
            {
                return;
            }

            public virtual void ExitState()
            {
                return;
            }
        }
    }
}
