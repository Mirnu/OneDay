using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item: MonoBehaviour
{
    public ItemInfo ItemInfo { get; private set; }

    public abstract void OnUse();
}
