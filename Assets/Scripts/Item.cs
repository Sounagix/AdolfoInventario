using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Espada", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField]
    private Sprite img;

    [SerializeField]
    private string nombre;

    [SerializeField]
    private GameObject itemPrefab;
}
