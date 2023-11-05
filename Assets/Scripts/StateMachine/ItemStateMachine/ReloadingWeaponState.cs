using UnityEngine;

namespace Astrocat
{
    namespace StateMachine
    {
        public class ReloadingWeaponState : BaseState
        {
            private AbstractWeaponStateManager stateManager;
            private float reloadTime;

            public ReloadingWeaponState(AbstractWeaponStateManager stateManager) { 
                this.stateManager = stateManager;
            }

            public override void EnterState()
            {
                reloadTime = stateManager.Weapon.WeaponData.reloadTime;
            }

            public override void StateUpdate()
            {
                if (reloadTime <= 0) {
                    stateManager.Weapon.AmmoLeft = stateManager.Weapon.WeaponData.maxAmmo;
                    stateManager.SwitchState(stateManager.ReloadedState); 
                }

                reloadTime -= Time.deltaTime;
            }
        }
    }
}