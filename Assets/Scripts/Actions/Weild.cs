using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Action/new equipable", fileName = "equipable")]
public class Weild : ItemAction
{
    public override int DoAction(Transform tr, GameObject prefab)
    {
        Instantiate(prefab, tr);
        return 0;
    }
}
