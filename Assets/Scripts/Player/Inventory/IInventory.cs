using UnityEngine;

namespace Astrocat
{
    namespace Player
    {
        namespace Inventory
        {
            public interface IInventory
            {
                public void AddToInventory(GameObject weaponToAdd);
                public void ChooseWeapon(int weaponIndex);
            }
        }
    }
}
