using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public string description;
    public int cost;
    public int amount;
}
