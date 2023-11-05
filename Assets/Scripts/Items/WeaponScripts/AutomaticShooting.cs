using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class AutomaticShooting : IShoot
            {

                private WeaponBase weaponBase;
                private Coroutine lastCoroutine;
                private float lastShotTime;

                public AutomaticShooting(WeaponBase weaponBase)
                {
                    this.weaponBase = weaponBase;
                    lastShotTime = -10f;
                }

                public void Shoot(InputAction.CallbackContext context)
                {
                    lastCoroutine = weaponBase.StartCoroutine(ShootAutomaticly());
                }

                private void StopAutomaticShooting(InputAction.CallbackContext context)
                {
                    if(lastCoroutine != null) weaponBase.StopCoroutine(lastCoroutine);
                }

                private IEnumerator ShootAutomaticly()
                {
                    if (!CanShoot()) yield return new WaitForSeconds(lastShotTime + weaponBase.WeaponData.shotCooldown - Time.time);
                    
                    while (weaponBase.AmmoLeft > 0)
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
                        lastShotTime = Time.time;
                        yield return new WaitForSeconds(weaponBase.WeaponData.shotCooldown);
                    }

                    yield break;
                }

                public void ConnectToInputSystem()
                {
                    PlayerInput.instance.playerInputActions.Player.ContinuousUsage.started += Shoot;
                    PlayerInput.instance.playerInputActions.Player.ContinuousUsage.canceled += StopAutomaticShooting;
                }

                public void DisconnectFromInputSystem()
                {
                    PlayerInput.instance.playerInputActions.Player.ContinuousUsage.started -= Shoot;
                    PlayerInput.instance.playerInputActions.Player.ContinuousUsage.canceled -= StopAutomaticShooting;

                    if (lastCoroutine != null) weaponBase.StopCoroutine(lastCoroutine);
                }

                private bool CanShoot()
                {
                    return Time.time >= lastShotTime + weaponBase.WeaponData.shotCooldown;
                }
            }
        }
    }
}
