using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    [SerializeField] string itemName; // �A�C�e���̖��O
    [SerializeField] Sprite icon; // �A�C�e���̉摜

    // ...

    public string GetItemName()
    {
        return itemName;
    }

    // �A�C�R���摜���擾����
    public Sprite GetIcon()
    {
        return icon;
    }

    // ...

}