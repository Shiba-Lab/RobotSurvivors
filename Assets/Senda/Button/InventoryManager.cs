using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<GameObject> inventoryItems = new List<GameObject>();

    public void AddItemToInventory(GameObject item)
    {
        inventoryItems.Add(item);
        // �����ŃA�C�e����K�؂Ȉʒu�ɔz�u���鏈��������
    }
}

