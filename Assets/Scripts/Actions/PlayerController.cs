using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public PlayerStats stats;

    public Transform weaponhand;

    public Vector3Int position => Vector3Int.RoundToInt(transform.position);

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private DataManager dataManager;

    private const int MAX_PLAYER_HEALTH = 100;

    private Vector3 initPosition;

    private Item equipedItem;

    // Start is called before the first frame update
    void Start()
    {
        stats.health = 50;
        stats.position = position;
        initPosition = transform.position;
        slider.maxValue = MAX_PLAYER_HEALTH;
        slider.value = stats.health;
    }

    // Update is called once per frame
    void Update()
    {
        stats.position = position;
    }

    public void GetDamage(int dmg)
    {
        stats.health -= dmg;
        slider.value = stats.health;
        if (stats.health <= 0)
        {
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        transform.position = initPosition;
        stats.health = MAX_PLAYER_HEALTH;
        slider.value = stats.health;
    }

    public void HealPlayer(int amount)
    {
        stats.health += amount;
        slider.value = stats.health;
        if (stats.health > MAX_PLAYER_HEALTH)
        {
            stats.health = MAX_PLAYER_HEALTH; 
        }
    }

    public Item GetEquipedItem()
    {
        return equipedItem;
    }

    public void EquipItem(Item _item) 
    {
        print("Eq " + _item.itemName);
        equipedItem = _item;
    }


    public void SaveEquipedItemOnInventory()
    {
       if (equipedItem != null)
        {
            int cont = 0;
            do
            {
                if (weaponhand.GetChild(cont).CompareTag("Item"))
                {
                    weaponhand.GetChild(cont).gameObject.SetActive(false);
                    //Destroy(weaponhand.GetChild(cont));
                }
                cont++;
            }
            while (cont < weaponhand.childCount);
            dataManager.AddItemAtEmptySlot(equipedItem);
            equipedItem = null;
        }
    }
}
