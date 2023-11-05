using UnityEngine;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        { 
            public class PickUpWeapon : MonoBehaviour
            {
                [SerializeField]
                private GameEvent onWeaponPickUp;

                private void OnTriggerEnter2D(Collider2D collision)
                {
                    onWeaponPickUp.TriggerEvent(this);
                }
            }
        }
    }
}
