using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public interface IInventory
{
    public void SetItem(Item item, int count=1);
    public void DeleteItem(Item item, int count=1);
    public Dictionary<Item, int> GetCurrentState();
    public void SetInventoryState(Dictionary<Item, int> items);
}
