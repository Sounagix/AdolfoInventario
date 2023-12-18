using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item/new item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;

    public string itemName;

    public string description;

    public bool stackable;

    public GameObject itemPrefab;

    public ItemAction action;

    public int ExecuteAction(Transform _tr, GameObject _prefab)
    {
        return action.DoAction(_tr,_prefab);
    }
}
