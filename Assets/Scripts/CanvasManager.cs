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

    void Start()
    {
        descriptionText.text = "";
    }

    public void InicializaInventario()
    {
        int indiceBoton = 0;
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i] != null)
            {
                InventoryButton iB = buttons[indiceBoton].GetComponent<InventoryButton>();
                iB.Init(this, inventory.slots[i].item);
                iB.SetButtonImg(inventory.slots[i].item.itemIcon);
                iB.SetAmount(inventory.slots[i].amount);
                indiceBoton++;
            }
        }
    }

    public void WriteDescription(string description)
    {
        descriptionText.text = description;
    }

}
