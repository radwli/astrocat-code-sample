using UnityEngine;

namespace Astrocat
{
    namespace StateMachine
    {
        public class ReloadedWeaponState : BaseState
        {
            private AbstractWeaponStateManager stateManager;

            public ReloadedWeaponState(AbstractWeaponStateManager stateManager)
            {
                this.stateManager = stateManager;    
            }

            public override void EnterState()
            {
                stateManager.Weapon.ShootingType.ConnectToInputSystem();
            }

            public override void ExitState()
            {
                stateManager.Weapon.ShootingType.DisconnectFromInputSystem();
            }

            public override void StateUpdate()
            {
                if (stateManager.Weapon.AmmoLeft > 0) return;

                stateManager.SwitchState(stateManager.ReloadingState);
            }
        }
    }
}
