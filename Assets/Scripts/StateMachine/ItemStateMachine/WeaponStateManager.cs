using Astrocat.Items.Weapons;

namespace Astrocat
{
    namespace StateMachine
    {
        public class WeaponStateManager : AbstractWeaponStateManager
        {
            private BaseState _currentState;
            private BaseState _reloadedState;
            private BaseState _reloadingState;
            private BaseState _inactiveState;
            private WeaponBase _weapon;

            public override BaseState CurrentState { get => _currentState; set => _currentState = value; }
            public override BaseState ReloadedState { get => _reloadedState; protected set => _reloadedState = value; }
            public override BaseState ReloadingState { get => _reloadingState; protected set => _reloadingState = value; }
            public override BaseState InactiveState { get => _inactiveState; protected set => _inactiveState = value; }
            public override WeaponBase Weapon { get => _weapon; protected set => _weapon = value; }

            private void Awake()
            {
                if(TryGetComponent<WeaponBase>(out WeaponBase weapon))
                {
                    Weapon = weapon;
                }
                else
                {
                    throw new System.Exception("Weapon state manager needs WeaponBase component");
                }

                ReloadedState = new ReloadedWeaponState(this);
                InactiveState = new InactiveWeaponState();
                ReloadingState = new ReloadingWeaponState(this);
            }

            private void Start()
            {
                CurrentState = InactiveState;
                CurrentState.EnterState();
            }

            private void Update()
            {
                CurrentState.StateUpdate();
            }

            public override void SwitchState(BaseState state)
            {
                CurrentState.ExitState();
                CurrentState = state;
                CurrentState.EnterState();
            }
        }
    }
}
