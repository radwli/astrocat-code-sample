using UnityEngine.InputSystem;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public interface IShoot
            {
                public void ConnectToInputSystem();
                public void DisconnectFromInputSystem();
                public void Shoot(InputAction.CallbackContext context);
            }
        }
    }
}
