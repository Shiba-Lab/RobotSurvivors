using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    [SerializeField] string itemName; // アイテムの名前
    [SerializeField] Sprite icon; // アイテムの画像

    // ...

    public string GetItemName()
    {
        return itemName;
    }

    // アイコン画像を取得する
    public Sprite GetIcon()
    {
        return icon;
    }

    // ...

}