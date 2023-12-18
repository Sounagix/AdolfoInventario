using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : ScriptableObject
{
    public virtual int DoAction(Transform tr, GameObject prefab) { return 0; }
}

