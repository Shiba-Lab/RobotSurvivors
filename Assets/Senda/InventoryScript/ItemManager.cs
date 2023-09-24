using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //�@�A�C�e���f�[�^�x�[�X
    [SerializeField]
    private ItemDataBase itemDataBase;
    //�@�A�C�e�����Ǘ�
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();


    static ItemManager instance;

    public static ItemManager GetInstance()
    {
        return instance;
    }

    // ...

    // Use this for initialization
    void Start()
    {
        instance = this;

        // ...
    }

    // ...

    public bool HasItem(string searchName)
    {
        return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
    }


    //�@���O�ŃA�C�e�����擾
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}