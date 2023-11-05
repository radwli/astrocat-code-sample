using UnityEngine;
using Astrocat.Items.Weapons;

namespace Astrocat
{
    namespace StateMachine
    {
        public abstract class AbstractWeaponStateManager : MonoBehaviour, IStateManager
        {
            public abstract BaseState ReloadedState { get; protected set; }
            public abstract BaseState ReloadingState { get; protected set; }
            public abstract BaseState InactiveState { get; protected set; }
            public abstract BaseState CurrentState { get; set; }
            public abstract WeaponBase Weapon { get; protected set; }

            public abstract void SwitchState(BaseState state);
        }
    }
}