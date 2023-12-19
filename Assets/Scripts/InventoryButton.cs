using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Sprite defaultImg;

    [SerializeField]
    private TextMeshProUGUI amountText;

    [SerializeField]
    private Button button;

    private Item item;

    private bool invoked = false;


    public void SetButtonImg(Sprite _img)
    {
        image.sprite = _img;
    }

    public void SetAmount(int _amount)
    {
        amountText.text = _amount.ToString(); 
    }

    public void Init(CanvasManager canvasManager, Item _item)
    {
        item = _item;
    }

    public void ResetButton()
    {
        image.sprite = defaultImg;
        amountText.text = "0";
    }

    public Button GetButton()
    {
        return button;
    }

    public Item GetItem()
    {
        return item;
    }

    public void AddOnCLickEvent(Item _item, PlayerController playerController, CanvasManager canvasManager)
    {
        if (!invoked)
        {
            invoked = true;
            button.onClick.AddListener(
                delegate ()
                {
                    Item equipedItem = playerController.GetEquipedItem();
                    if (equipedItem != null)
                    {
                        playerController.SaveEquipedItemOnInventory();
                    }
                    canvasManager.RemoveItemButton(_item);
                    playerController.EquipItem(_item);
                    canvasManager.WriteDescription(_item.description);
                    _item.ExecuteAction(playerController.weaponhand, _item.itemPrefab);
                });
        }

    }

    public void RemoveEvent()
    {
        button.onClick.RemoveAllListeners();
        invoked = false;
    }
}
