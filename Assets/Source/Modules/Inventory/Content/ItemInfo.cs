using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInfo : ScriptableObject
{
    [SerializeField] private int Id;
    [SerializeField] private string Name = "item_name";
    [SerializeField] private Sprite InventorySprite;
    [SerializeField] private string Description;
}
