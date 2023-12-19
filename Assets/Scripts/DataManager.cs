using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


#if UNITY_EDITOR
    public int GetInventoryCount()
    {
        return _inventory == null ? 0 : _inventory.slots.Count;
    }
#endif

    public SlotInventory GetStlotByIndex(int _index)
    {
#if UNITY_EDITOR
        if (_inventory == null)
        {
            Debug.LogError("La variable _inventory de DataManager es null");
            return null;
        }

        if (_inventory.slots == null )
        {
            Debug.LogError("Repasa el archivo inventario de la carpeta Data. Estará sin items");
            return null;
        }
#endif
        return _inventory.slots[_index];
    }

    public SlotInventory GetStlotByName(string _name)
    {
#if UNITY_EDITOR
        if (_inventory == null)
        {
            Debug.LogError("La variable _inventory de DataManager es null");
            return null;
        }

        if (_inventory.slots == null)
        {
            Debug.LogError("Repasa el archivo inventario de la carpeta Data. Estará sin items");
            return null;
        }
#endif
        bool finded = false;
        int aux = 0;
        do
        {
            if (_inventory.slots[aux].item != null && _inventory.slots[aux].item.itemName == _name)
            {
                finded = true;
            }
            else
            {
                aux++;
            }
        }
        while (!finded && aux < _inventory.slots.Count);

        return finded ? _inventory.slots[aux] : null;
    }

    public void InsertItemAtPosition(SlotInventory _slot, int _index)
    {
        if (_index < _inventory.slots.Count && _index >= 0)
        {
            _inventory.slots[_index] = _slot;
        }
    }

    public void AddItem(SlotInventory _slot)
    {
        int index = -1;

        if (_inventory.slots.Contains(_slot) && _slot.item.stackable)
        {
            //System.Predicate<SlotInventory> predicate = _item => _item.item.name == _slot.item.name;
            index = _inventory.slots.FindIndex(X => X.item.itemName.Equals(_slot.item.itemName));

            if (index >= 0)
            {
                _inventory.slots[index].amount++;
            }
        }
        else
        {
            AddItemAtEmptySlot(_slot.item);
        }
    }
     
    public int AddItemAtEmptySlot(Item _item)
    {
        int index = _inventory.slots.FindIndex(X => X.item == null);
        if (index >= 0)
        {
            _inventory.slots[index].item = _item;
            _inventory.slots[index].amount = 1;
            return index;
        }
        else
        {
            Debug.Log("Inventario lleno");
            return -1;
        }
    }

    public void RemoveItemAt(int _index)
    {
        _inventory.slots[_index].amount--;
        if (_inventory.slots[_index].amount < 0)
        {
            _inventory.slots[_index].amount = 0;
            _inventory.slots[_index].item = null;

            //for (int i = _index; i < _inventory.slots.Count; i++)
            //{
            //    MoveDownItemAtPosition(i);
            //    if (i == _inventory.slots.Count - 1)
            //    {
            //        _inventory.slots[i].amount = 0;
            //        _inventory.slots[i].item = null;
            //    }
            //}
        }
    }


    public void MoveDownItemAtPosition(int _index)
    {
        if (((_index + 1) > _inventory.slots.Count) || _index > 0) return;

        _inventory.slots[_index] = _inventory.slots[_index + 1];
    }

    public void ChangePositions()
    {

    }

}
