using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class ManualWeapon : WeaponBase
            {
                private void Awake()
                {
                    ShootingType = new ManualShooting(this);
                    AmmoLeft = WeaponData.maxAmmo;
                }
            }
        }
    }
}