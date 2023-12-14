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
        InicializaInventario();
        descriptionText.text = "";
    }

    private void InicializaInventario()
    {
        int indiceBoton = 0;
        for (int i = 0; i < inventory.inventary.Count; i++)
        {
            if (inventory.inventary[i] != null)
            {
                InventoryButton iB = buttons[indiceBoton].GetComponent<InventoryButton>();
                iB.Init(this, inventory.inventary[i].item);
                iB.SetButtonImg(inventory.inventary[i].item.itemIcon);
                iB.SetAmount(inventory.inventary[i].amount);
                indiceBoton++;
            }
        }
    }

    public void WriteDescription(string description)
    {
        descriptionText.text = description;
    }

}
