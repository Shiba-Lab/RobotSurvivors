using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<GameObject> inventoryItems = new List<GameObject>();

    public void AddItemToInventory(GameObject item)
    {
        inventoryItems.Add(item);
        // ここでアイテムを適切な位置に配置する処理を実装
    }
}

