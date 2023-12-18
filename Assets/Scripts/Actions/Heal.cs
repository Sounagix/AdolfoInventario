using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/Action/new posionVida", fileName = "posionVida")]
public class Heal : ItemAction
{
    public int points;

    public override int DoAction(Transform tr, GameObject prefab)
    {
        return points;
    }
}
