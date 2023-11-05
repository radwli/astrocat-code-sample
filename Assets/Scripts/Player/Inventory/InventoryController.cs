using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Astrocat
{
    namespace Player
    {
        namespace Inventory
        {
            public class InventoryController : MonoBehaviour
            {
                [SerializeField]
                private GameObject weaponStorage;

                private Inventory inventory;

                private void Awake()
                {
                    inventory = new Inventory(weaponStorage);
                }

                private void Start()
                {
                    PlayerInput.instance.playerInputActions.Player.ChooseInventorySlot.performed += ChooseItem;
                }

                private void OnDisable()
                {
                    PlayerInput.instance.playerInputActions.Player.ChooseInventorySlot.performed -= ChooseItem;
                }

                public void OnWeaponAdded(Component component)
                {
                    GameObject weaponToAdd = component.gameObject;
                    Debug.Log("Trying to add weapon to inventory");
                    inventory.AddToInventory(weaponToAdd);
                }

                public void ChooseItem(InputAction.CallbackContext context)
                {
                    int chosenSlotNumber = Int32.Parse(context.action.activeControl.name);

                    inventory.ChooseWeapon(chosenSlotNumber-1);
                }

            }
        }
    }
}