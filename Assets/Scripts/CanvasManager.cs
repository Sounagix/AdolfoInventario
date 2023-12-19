using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    private PlayerController playerController;

    void Start()
    {
        descriptionText.text = "";
    }

    public void InicializaInventario()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i] != null && inventory.slots[i].item != null)
            {
                InventoryButton iB = buttons[i].GetComponent<InventoryButton>();
                iB.Init(this, inventory.slots[i].item);
                iB.RemoveEvent();
                iB.AddOnCLickEvent(inventory.slots[i].item, playerController, this);
                iB.SetButtonImg(inventory.slots[i].item.itemIcon);
                iB.SetAmount(inventory.slots[i].amount);
            }
        }
    }

    public void RemoveItemButton(Item item)
    {
        bool encontrado = false;
        int cont = 0;
        do
        {
            Item currentItem = buttons[cont].GetComponent<InventoryButton>().GetItem();
            if ( currentItem != null && currentItem == item)
            {
                encontrado = true;
            }
            else
            {
                cont++;
            }
        }
        while (!encontrado && cont < buttons.Length);
        if(encontrado)
        {
            buttons[cont].GetComponent<InventoryButton>().ResetButton();
            //var slot = DataManager.instance.GetStlotByIndex(cont);
            DataManager.instance.RemoveItemAt(cont);
        }
    }

    public void WriteDescription(string description)
    {
        descriptionText.text = description;
    }

    public void QuitEvents()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            InventoryButton iB = buttons[i].GetComponent<InventoryButton>();
            iB.RemoveEvent();
        }
    }
}
