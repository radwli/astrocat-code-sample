using UnityEngine;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class BulletCollisionHandler : MonoBehaviour
            {
                private void OnCollisionEnter2D(Collision2D collision)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}