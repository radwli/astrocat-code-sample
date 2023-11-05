using UnityEngine;

namespace Astrocat
{
    namespace Items
    {
        public class HeldWeaponRotation : MonoBehaviour
        {
            private Vector2 pointerPosition;

            private void Update()
            {
                pointerPosition = PlayerInput.instance.GetPointerInput();

                Vector2 direction = (pointerPosition - (Vector2)transform.position).normalized;

                transform.right = direction;

                Vector2 scale = transform.localScale;

                if (direction.x < 0)
                {
                    scale.y = -1;
                }
                else if (direction.x > 0)
                {
                    scale.y = 1;
                }

                transform.localScale = scale;
            }
        }
    }
}
