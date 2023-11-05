using UnityEngine;

namespace Astrocat
{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item/Weapon/Ranged")]
    public class WeaponScriptableObject : ItemScriptableObject
    {
        public float damage;
        public float shotCooldown;
        public float reloadTime;
        public float knockback;
        public float recoil;

        public int maxAmmo;
    }
}