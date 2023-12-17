using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotInventory
{
    public int amount = 0;

    public Item item;

    public SlotInventory(Item _item, int _amount = 1)
    {
        item = _item;
        amount = _amount;
    }
}
