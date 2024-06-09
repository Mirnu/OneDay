using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour, IInventory
{
    private Dictionary<Item, int> items;
    public void DeleteItem(Item item, int count = 1)
    {
        if (!items.ContainsKey(item)) return;
        if ((items[item] - count) >= 0)
            items[item] -= count;
        else
            items[item] = 0;
    }

    public Dictionary<Item, int> GetCurrentState()
    {
        return items;
    }

    public void SetInventoryState( Dictionary<Item, int> items)
    {
        this.items = items;
    }

    public void SetItem(Item item, int count=1)
    {
        if (!items.ContainsKey(item))
            items.Add(item, 1);
        else
            items[item] += count;
    }
}
