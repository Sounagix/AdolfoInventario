using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Collectable : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController controller;

    [SerializeField]
    private DataManager dataManager;

    [SerializeField]
    private Item item;

    public bool isHover;

    private void Awake()
    {
        controller.activateAction.action.started += Action_started;
    }

    private void Action_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isHover)
        {
            SlotInventory slot = dataManager.GetStlotByName(item.itemName);

            if (slot == null)
            {
                SlotInventory newSlot = new SlotInventory(item);
                dataManager.AddItem(newSlot);
            }
            else
            {
                dataManager.AddItem(slot);
            }
            Destroy(gameObject);
        }
    }

    public void OnHoverEnter()
    {
        isHover = true;
    }

    public void OnHoverExit()
    {
        isHover = false;
    }
}
