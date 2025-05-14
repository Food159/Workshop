using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
//using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public List<ItemData> inventoryList;
    public void AddItem(ItemData item)
    {
        inventoryList.Add(item);
    }
    public int GetItemAmount(ItemData targetItem) 
    {
        int amount = 0;
        foreach(ItemData item in inventoryList)
        {
            if(item == targetItem) amount++;
        }
        return amount;
    }
}
