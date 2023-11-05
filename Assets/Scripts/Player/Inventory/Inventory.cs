using UnityEngine;
using Astrocat.StateMachine;

namespace Astrocat
{
    namespace Player
    {
        namespace Inventory
        {
            public class Inventory : IInventory
            {
                private GameObject weaponStorage;

                private GameObject[] weapons = new GameObject[8];
                private GameObject currentlyUsedWeapon;

                public Inventory(GameObject weaponStorage)
                {
                    this.weaponStorage = weaponStorage;
                }

                public void AddToInventory(GameObject weaponToAdd)
                {
                    for (int i = 0; i < weapons.Length; i++)
                    {
                        if (weapons[i] != null) continue;

                        weapons[i] = weaponToAdd;
                        
                        weaponToAdd.GetComponent<CircleCollider2D>().enabled = false;
                        weaponToAdd.transform.parent = weaponStorage.transform;
                        weaponToAdd.transform.localPosition = new Vector3(0.5f, 0, 0);
                        weaponToAdd.transform.localRotation = Quaternion.identity;
                        weaponToAdd.transform.localScale = new Vector3(1, 1, 0);

                        weaponToAdd.gameObject.SetActive(false);
                        break;
                    }
                }

                public void ChooseWeapon(int weaponIndex)
                {
                    if (weapons[weaponIndex] == null) return;
                    if (weapons[weaponIndex] == currentlyUsedWeapon) return;

                    if (currentlyUsedWeapon != null)
                    {
                        if (currentlyUsedWeapon.TryGetComponent<WeaponStateManager>(out WeaponStateManager currentlyUsedWeaponManager))
                        {
                            currentlyUsedWeaponManager.SwitchState(currentlyUsedWeaponManager.InactiveState);
                        }
                        currentlyUsedWeapon.SetActive(false);
                    }

                    weapons[weaponIndex].SetActive(true);
                    if (weapons[weaponIndex].TryGetComponent<WeaponStateManager>(out WeaponStateManager chosenWeaponManager))
                    {
                        chosenWeaponManager.SwitchState(chosenWeaponManager.ReloadedState);
                    }

                    currentlyUsedWeapon = weapons[weaponIndex];
                }
            }
        }
    }
}