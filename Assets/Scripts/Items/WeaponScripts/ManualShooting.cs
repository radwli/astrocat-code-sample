using UnityEngine;
using UnityEngine.InputSystem;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class ManualShooting : IShoot
            {
                private WeaponBase weaponBase;
                private float lastShotTime;

                public ManualShooting(WeaponBase weaponBase)
                {
                    this.weaponBase = weaponBase;
                    lastShotTime = -10f;
                }

                public void Shoot(InputAction.CallbackContext context)
                {
                    if (!CanShoot()) return;

                    if(weaponBase.AmmoLeft > 0)
                    {
                        foreach (Transform outlet in weaponBase.Outlets)
                        {
                            GameObject bullet = ObjectPool.instance.GetPooledObject();

                            if (bullet != null)
                            {
                                bullet.transform.position = outlet.position;
                                bullet.transform.rotation = weaponBase.AnchorPoint.rotation;

                                Vector2 shootDirection = ((Vector2)outlet.position - (Vector2)weaponBase.AnchorPoint.position).normalized;

                                bullet.SetActive(true);
                                bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * 900f);
                            }
                        }
                        weaponBase.AmmoLeft--;
                        lastShotTime= Time.time;
                    }
                }

                public void ConnectToInputSystem()
                {
                    PlayerInput.instance.playerInputActions.Player.ItemUsage.performed += Shoot;
                }

                public void DisconnectFromInputSystem()
                {
                    PlayerInput.instance.playerInputActions.Player.ItemUsage.performed -= Shoot;
                }


                private bool CanShoot()
                {
                    return Time.time >= lastShotTime + weaponBase.WeaponData.shotCooldown;
                }
            }
        }
    }
}