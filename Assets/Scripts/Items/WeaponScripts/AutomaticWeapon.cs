namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class AutomaticWeapon : WeaponBase
            {
                private void Awake()
                {
                    ShootingType = new AutomaticShooting(this);
                    AmmoLeft = WeaponData.maxAmmo;
                }
            }
        }
    }
}

