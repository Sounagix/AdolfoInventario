using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/new inventory", fileName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<SlotInventory> inventary;
}
