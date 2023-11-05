namespace Astrocat
{
    namespace StateMachine
    {
        public interface IStateManager
        {
            public BaseState CurrentState { get; set; }

            public void SwitchState(BaseState state);
        }
    }
}