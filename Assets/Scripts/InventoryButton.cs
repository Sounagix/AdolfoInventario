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
    private TextMeshProUGUI amountText;

    [SerializeField]
    private Button button;

    public void SetButtonImg(Sprite _img)
    {
        image.sprite = _img;
    }

    public void SetAmount(int _amount)
    {
        amountText.text = _amount.ToString(); 
    }

    private void AddEvent(CanvasManager _canvasManager, Item item)
    {
        button.onClick.AddListener(
            delegate ()
            {
                _canvasManager.WriteDescription(item.description);
            });
    }

    public void Init(CanvasManager canvasManager, Item item)
    {
        AddEvent(canvasManager, item);
    }
}
